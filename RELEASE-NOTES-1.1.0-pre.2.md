# Lingam's Panning Tweak v1.1.0-pre.2

**Vintage Story compatibility: 1.23.0-pre.2 only.** This is a prerelease for players testing Vintage Story 1.23.0-pre.2. Do not install it with 1.22.x.

**Packaging update:** The in-game Mod Manager description has been shortened to a single concise line. No gameplay code or mod version was changed in this refresh.

## New: Wading Stability

Let's face it, folks: when we're wading through a stream or panning for gold in real life, we don't helplessly float away every time the water moves! We're generally heavy enough to keep our footing in waist-deep, moderately flowing water.

- **Enabled automatically** for players who have not explicitly configured drift.
- While standing or walking on solid ground in flowing water, horizontal water-current push is suppressed.
- **Swimming, jumping, or being submerged (eyes underwater)** restores natural water-current forces, even when standing on the bottom.
- Does not alter animal movement, vertical water force, or panning rewards.
- Saved player preferences continue to be respected.

Commands:
- `/panning drift` — check your current setting.
- `/panning drift on` — enable vanilla current drifting.
- `/panning drift off` — enable Wading Stability.

## Existing panning improvements

- Pan from beneath overhead blocks.
- Take material from the top of a continuous stack of pannable material.
- See which material will be panned from the top in the block-information tooltip.
- Vanilla panning rewards remain unchanged.

## Testing status and feedback

The preceding `v1.1.0-pre.1` preview passed the reported single-player panning, drift command, movement, and persistence tests. **This build adjusts the default behavior and underwater condition; those changes require an additional in-game confirmation.** Multiplayer has not been independently verified.

Report problems at https://github.com/wesley947/LingamsPanningTweak/issues.

The existing stable 1.22.x-compatible v1.0.0 release remains available separately.
