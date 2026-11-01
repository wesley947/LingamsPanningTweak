using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace PanningMod;

public class PanningModSystem : ModSystem
{
    private const string PatchId = "lingamspanningtweak";
    private static readonly object PatchLock = new();
    private static Harmony sharedHarmony;
    private static int activeInstances;
    private bool started;

    public override void Start(ICoreAPI api)
    {
        lock (PatchLock)
        {
            if (started) return;

            if (activeInstances == 0)
            {
                var harmony = new Harmony(PatchId);
                harmony.PatchAll(typeof(PanningModSystem).Assembly);
                sharedHarmony = harmony;
            }

            activeInstances++;
            started = true;
        }
    }

    public override void Dispose()
    {
        lock (PatchLock)
        {
            if (!started) return;

            started = false;
            activeInstances--;

            if (activeInstances == 0)
            {
                sharedHarmony?.UnpatchAll(PatchId);
                sharedHarmony = null;
            }
        }
    }
}

[HarmonyPatch(typeof(BlockPan), "TryTakeMaterial")]
internal static class PanMaterialPatch
{
    [HarmonyPrefix]
    private static bool Prefix(
        BlockPan __instance,
        ItemSlot slot,
        EntityAgent byEntity,
        BlockPos position)
    {
        var world = byEntity.World;
        var blocks = world.BlockAccessor;

        if (!__instance.IsPannableMaterial(blocks.GetBlock(position)))
            return true;

        // Find the highest block in this continuous pannable column.
        var top = position.Copy();

        while (top.Y + 1 < blocks.MapSizeY &&
               __instance.IsPannableMaterial(blocks.GetBlock(top.UpCopy())))
        {
            top.Up();
        }

        // Respect permissions at the block we actually consume.
        var player = (byEntity as EntityPlayer)?.Player;
        if (player == null ||
            !world.Claims.TryAccess(
                player, top, EnumBlockAccessFlags.BuildOrBreak))
            return false;

        var block = blocks.GetBlock(top);
        string layer = block.Variant["layer"];

        if (layer != null)
        {
            // Preserve vanilla's original material identification.
            string baseCode =
                block.FirstCodePart() + "-" + block.FirstCodePart(1);

            var original = world.GetBlock(new AssetLocation(block.Code.Domain, baseCode));
            if (original == null) return false;

            int nextId = 0;

            if (layer != "1")
            {
                if (!int.TryParse(layer, out int level) || level <= 1)
                    return false;

                var next = world.GetBlock(
                    block.CodeWithVariant("layer", (level - 1).ToString()));

                if (next == null) return false;
                nextId = next.BlockId;
            }

            __instance.SetMaterial(slot, original);
            blocks.SetBlock(nextId, top);
        }
        else
        {
            // Preserve vanilla's custom pannedBlock behavior.
            string pannedCode = block.Attributes["pannedBlock"].AsString();

            var next = pannedCode != null
                ? world.GetBlock(AssetLocation.Create(
                    pannedCode, block.Code.Domain))
                : world.GetBlock(block.CodeWithVariant("layer", "7"));

            if (next == null)
            {
                world.Logger.Warning(
                    "Missing panned block for " + block.Code);
                return false;
            }

            __instance.SetMaterial(slot, block);
            blocks.SetBlock(next.BlockId, top);
        }

        blocks.TriggerNeighbourBlockUpdate(top);
        slot.MarkDirty();

        // Skip only vanilla's material-collection method.
        return false;
    }
}

[HarmonyPatch(typeof(Block), nameof(Block.GetPlacedBlockInfo))]
internal static class PanningBlockInfoPatch
{
    [HarmonyPostfix]
    private static void Postfix(
        Block __instance,
        IWorldAccessor world,
        BlockPos pos,
        IPlayer forPlayer,
        ref string __result)
    {
        var slot = forPlayer?.InventoryManager?.ActiveHotbarSlot;

        if (slot?.Itemstack?.Collectible is not BlockPan pan)
            return;

        // Only show when the pan is empty.
        if (pan.GetBlockMaterialCode(slot.Itemstack) != null)
            return;

        var blocks = world.BlockAccessor;
        if (!pan.IsPannableMaterial(blocks.GetBlock(pos)))
            return;

        // Find the highest connected pannable block.
        var top = pos.Copy();

        while (top.Y + 1 < blocks.MapSizeY &&
               pan.IsPannableMaterial(blocks.GetBlock(top.UpCopy())))
        {
            top.Up();
        }

        // Nothing to explain for ordinary single-block panning.
        if (top.Y == pos.Y)
            return;

        // Use Vintage Story's actual localized block name.
        var topBlock = blocks.GetBlock(top);
        string materialName = topBlock.GetPlacedBlockName(world, top);

        if (string.IsNullOrWhiteSpace(materialName))
            return;

        string message = "Will pan " + materialName + " from the top";

        __result = string.IsNullOrWhiteSpace(__result)
            ? message
            : __result.TrimEnd() + "\n" + message;
    }
}