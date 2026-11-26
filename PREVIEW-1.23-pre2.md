# 1.23.0-pre.2 development preview

**Lingam's Panning Tweak 1.1.0-pre.1** is an experimental build for **Vintage Story 1.23.0-pre.2**. This branch is not a published ModDB release. All listed single-player gameplay checks for the current preview have been reported passing. Planned behavior refinements and a subsequent rebuild still require verification.

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

## In-game test record — November 26, 2026

Reported by tester on Vintage Story 1.23.0-pre.2 using mod 1.1.0-pre.1:

- [x] Starts and loads without a reported panning-mod or Harmony startup exception.
- [x] Ordinary panning works (at least two successful panning actions).
- [x] Top-down panning / top-of-stack collection works.
- [x] `/panning drift off` immediately stops horizontal drift while grounded in flowing water.
- [x] Walking and panning normally with drift off still work.
- [x] Explicit drift state persists across closing and re-entering the game.
- [x] Panning with an overhead solid block works (tester-reported).
- [x] Top-of-stack tooltip and mixed-material vertical stacks (tester reports all remaining gameplay tests passed).
- [x] `/panning drift on` restores vanilla current behavior (tester-reported).
- [x] Jumping, swimming, submerged-water behavior, knockback, and animal movement reported passing with current preview. Recheck submerged grounded behavior after the explicit head-submersion change.
- [x] Feature behavior at shoreline/ground-contact transitions (tester reports all remaining gameplay tests passed).
- [ ] Multiplayer verification has not been separately confirmed; do not claim it tested.

**Test update:** On November 26, tester reported “all remaining tests passed” after separately confirming top-down panning and persistence. This applies to the existing preview build, not the planned revisions below.

### Planned changes before release candidate

- New players should have **Wading Stability enabled by default** (i.e., vanilla current drift OFF), preserving explicitly saved preferences.
- Suppress drift only while grounded **and not submerged**. The current 1.1.0-pre.1 build checks grounded/not-swimming but does not yet explicitly check head submersion.
- Rebuild and retest after these changes; do not describe the current preview as final/release ready.

## Building

Requires .NET 10 SDK and the game installation for **1.23.0-pre.2**.

The project defaults to `%APPDATA%\\Vintagestory` for library references. If Pre2 is installed elsewhere, set `VINTAGE_STORY` to its folder before building:

```powershell
$env:VINTAGE_STORY = "C:\\Path\\To\\Vintage Story Pre2"
dotnet build .\\PanningMod.csproj -c Release
```

GitHub Actions on this branch is configured to download the public Pre2 server package to obtain matching game API assemblies, compile the DLL, and package a ZIP for testing. Its success still does not constitute in-game verification.

**The main branch and 1.0.0 ModDB release remain unchanged.**
