# 1.23.0-pre.2 development preview

**Lingam's Panning Tweak 1.1.0-pre.2** is an experimental build for **Vintage Story 1.23.0-pre.2**. This branch is not a published ModDB release. The earlier 1.1.0-pre.1 build passed the listed single-player gameplay tests. The 1.1.0-pre.2 default/submersion refinements still require in-game confirmation.

## Existing panning functionality

- Pan recognized materials even with a solid block above.
- Consume the top block of a continuous vertical pannable stack.
- Show which material will be collected when aiming below the top.

## Wading Stability / optional vanilla water drift

**Wading Stability is ON by default** for players without a saved drift preference: horizontal drift is suppressed when grounded and eyes are above water. Explicit player choices are preserved, including choices saved by v1.1.0-pre.1.

- `/panning drift off` — enable Wading Stability; suppress only the horizontal flowing-water impulse while grounded and not submerged.
- `/panning drift on` — restore vanilla current drift, even while wading.
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

### Changes in v1.1.0-pre.2 and remaining release checks

- [x] Code updated: New players have Wading Stability enabled by default; saved explicit choices persist.
- [x] Code updated: When eyes are submerged, water-current push applies even if grounded. Swimming and jumping remain vanilla.
- [x] Code updated: Exclude flowing lava from the wading correction.
- [x] Matching 1.23.0-pre.2 build completed with 0 warnings and 0 errors; GitHub Actions packaged and uploaded the mod ZIP (run 45887569529, artifact 15149753290).
- [ ] Smoke-test default, stored preferences, and submerged-grounded behavior in-game with v1.1.0-pre.2.
- [ ] Multiplayer separately unverified; do not claim it tested.

## Building

Requires .NET 10 SDK and the game installation for **1.23.0-pre.2**.

The project defaults to `%APPDATA%\\Vintagestory` for library references. If Pre2 is installed elsewhere, set `VINTAGE_STORY` to its folder before building:

```powershell
$env:VINTAGE_STORY = "C:\\Path\\To\\Vintage Story Pre2"
dotnet build .\\PanningMod.csproj -c Release
```

GitHub Actions on this branch is configured to download the public Pre2 server package to obtain matching game API assemblies, compile the DLL, and package a ZIP for testing. Its success still does not constitute in-game verification.

**The main branch and 1.0.0 ModDB release remain unchanged.**

**GitHub prerelease v1.1.0-pre.2 publishing requested November 26, 2026.** This remains a prerelease pending the short in-game confirmation of the changed default/submersion behavior; it is not yet published to Vintage Story ModDB.
