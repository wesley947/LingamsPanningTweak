# 1.23.0-pre.2 development preview

**Lingam's Panning Tweak 1.1.0-pre.1** is an experimental build for **Vintage Story 1.23.0-pre.2**. This branch is not a published ModDB release and has not yet been tested in-game.

## Existing panning functionality

- Pan recognized materials even with a solid block above.
- Consume the top block of a continuous vertical pannable stack.
- Show which material will be collected when aiming below the top.

## Optional water drift

This feature is **OFF by default** in the sense that no stabilization is applied: vanilla current drift is **ON** until a player opts out.

- `/panning drift off` — suppress only the horizontal flowing-water impulse while standing on solid ground.
- `/panning drift on` — restore vanilla current drift.
- `/panning drift` — show the current setting.
- `drift`, `on` and `off` are compared without regard to capitalization.
- The setting is per-player and stored as a synchronized, persistent entity attribute.
- Ordinary swimming, jumping, animal movement, vertical fluid movement, walking, other forces, and panning rewards are intended to remain unchanged.

## Test checklist before public release

1. Start a disposable or backed-up Pre2 world; verify the mod loads without Harmony exceptions.
2. Repeat covered-block and mixed vertical-stack panning tests.
3. Standing in shallow flowing water: `/panning drift off` should prevent horizontal current drift.
4. Restore `/panning drift on` and confirm vanilla current behavior returns.
5. Confirm walking, jumping, swimming, knockback, and animal motion remain vanilla.
6. Save and reopen the world: the drift setting should persist.
7. Test multiplayer sync separately before claiming multiplayer support.

## Building

Requires .NET 10 SDK and the game installation for **1.23.0-pre.2**.

The project defaults to `%APPDATA%\\Vintagestory` for library references. If Pre2 is installed elsewhere, set `VINTAGE_STORY` to its folder before building:

```powershell
$env:VINTAGE_STORY = "C:\\Path\\To\\Vintage Story Pre2"
dotnet build .\\PanningMod.csproj -c Release
```

GitHub Actions on this branch is configured to download the public Pre2 server package to obtain matching game API assemblies, compile the DLL, and package a ZIP for testing. Its success still does not constitute in-game verification.

**The main branch and 1.0.0 ModDB release remain unchanged.**
