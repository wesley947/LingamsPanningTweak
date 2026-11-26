# Lingam's Panning Tweak 1.1.0 — Vintage Story 1.22.7

**Stable-version game build. Compiled for Vintage Story 1.22.7; direct in-game verification on 1.22.7 is still pending.**

This build succeeds the original **v1.0.0**. It combines the existing panning features with Wading Stability.

- Pan underneath overhead blocks.
- Consume vertical stacks of pannable material from the top.
- Show top-of-stack material information in the tooltip.
- **Wading Stability is enabled by default** while standing/walking grounded in flowing water and eyes are above water.
- Normal water currents remain while swimming, jumping, or submerged; lava is not affected.
- `/panning drift on` restores vanilla current drift; `/panning drift off` enables Wading Stability; `/panning drift` reports preference.
- Per-player preference is designed to persist between sessions.

## Compatibility and verification

- **Compiled against the official Vintage Story 1.22.7 libraries**, using .NET 10.
- modinfo declares a 1.22.0 minimum for game and survival; *other 1.22.x patches have not been independently checked*.
- Packaging CI checks DLL, modinfo, and icon in the downloadable ZIP.
- The equivalent gameplay features were tested in the independent **1.23.0-pre.2** build, but that is not a substitute for an in-game test on 1.22.7.
- Multiplayer has not been tested.
- Do not install both 1.22.x and 1.23.x ZIPs at once.

**The existing v1.0.0 release remains available unchanged for rollback.**
