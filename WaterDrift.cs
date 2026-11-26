using System;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;

namespace PanningMod;

/// <summary>
/// Reverses only the horizontal flowing-water impulse when a player is
/// wading on the ground with drift disabled (the default).
/// No player positions, other velocity sources, or swimming physics are changed.
/// </summary>
[HarmonyPatch(typeof(PModuleInLiquid), nameof(PModuleInLiquid.DoApply))]
internal static class GroundedWaterDriftPatch
{
    // Physics might run on different threads; reuse the lookup position safely.
    [ThreadStatic] private static BlockPos lookupPos;

    [HarmonyPostfix]
    private static void Postfix(Entity entity, EntityPos pos, EntityControls controls)
    {
        // Never change animal physics, normal swimming, jumping, flight or noclip.
        if (entity is not EntityPlayer player || player.Swimming || !player.OnGround ||
            !player.FeetInLiquid || player.IsEyesSubmerged() || controls.Jump ||
            controls.IsFlying || controls.NoClip)
            return;

        // No attribute means default Wading Stability ON (vanilla drift OFF).
        // Explicit preferences are set by /panning drift on|off
        // on the server and synchronized to the owning client.
        if (entity.WatchedAttributes.GetBool(PanningModSystem.DriftAttributeKey, false))
            return;

        var world = entity.World;
        var blockAccessor = world.BlockAccessor;
        lookupPos ??= new BlockPos(pos.Dimension);
        lookupPos.Set(pos);

        Block water = blockAccessor.GetBlock(lookupPos, BlockLayersAccess.Fluid);
        if (water is not IBlockFlowing flowing || flowing.IsStill || flowing.IsLava)
            return;

        FastVec3f push = flowing.GetPushVector(lookupPos);

        // Match vanilla's rule: when down-flow cannot push a player through
        // solid ground, DoApply did not add *any* of this vector.
        if (push.Y < 0 && blockAccessor.IsSideSolid(
                (int)pos.X, (int)pos.InternalY - 1, (int)pos.Z, BlockFacing.UP))
            return;

        // DoApply has already added the flowing-water impulse. Subtract only
        // its horizontal part, leaving all non-water movement and Y intact.
        pos.Motion.X -= push.X;
        pos.Motion.Z -= push.Z;
    }
}
