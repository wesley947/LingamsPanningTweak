# Lingam's Panning Tweak

A lightweight quality-of-life mod for **Vintage Story** that extends ordinary hand panning while preserving vanilla rewards and animations. This branch targets **Vintage Story 1.22.7** with an additional Wading Stability option.

## Features

- **Pan beneath obstructions:** Collect pannable materials even when rock, dirt, or other blocks are above them.
- **Top-down collection:** When you target any block in a continuous vertical stack of pannable materials, one layer is collected from the highest pannable block in that stack.
- **Material-aware feedback:** While holding an empty pan and targeting a lower part of a stack, the block information display shows which material will be collected from above.
- **Wading Stability (1.1.0-rc.1):** Automatically prevents horizontal current push while grounded and wading, but leaves swimming, jumping, and submerged currents intact. Use `/panning drift on|off` to configure, or `/panning drift` to check your setting.
- **Vanilla-compatible approach:** Uses the game's existing pannable-material definitions rather than hardcoding a list of sand, gravel, and bony soil. Preserves the material type used for vanilla panning rewards and respects land claims.

The intent is to work with other appropriately defined pannable materials, although compatibility with every third-party mod cannot be guaranteed. Mods that directly change the vanilla pan's material-collection behavior may need additional testing.

## Installation

Download the mod ZIP from the [Vintage Story Mod Database](https://mods.vintagestory.at/) once published, place the ZIP in your Vintage Story **Mods** folder, and enable it in the Mod Manager. The mod is intended for both client and server use.

## Building from source

Requires the **.NET 10 SDK** and **Vintage Story 1.22.7** game libraries. The project references the game's `VintagestoryAPI.dll`, `VSSurvivalMod.dll`, and bundled `0Harmony.dll`; these game libraries are not redistributed here.

The project uses `%APPDATA%\Vintagestory` by default; set `VINTAGE_STORY` to override the game installation directory.

```powershell
dotnet build PanningMod.csproj -c Release
```

## Bug reports and suggestions

Please use [GitHub Issues](https://github.com/wesley947/LingamsPanningTweak/issues) for reproducible bugs, compatibility reports, or suggestions. Include your Vintage Story version and any relevant mods.

## Credits

Created and tested by **Lingam**, with AI assistance during development. This project is an optional gameplay tweak, not an official Vintage Story mod.

## License

MIT — see [LICENSE](LICENSE).

## 1.22.7 release candidate

The `v1.1.0-rc.1` package is **not yet tested inside 1.22.7**. It builds against the official 1.22.7 server libraries in GitHub Actions, which checks compile-time API compatibility and ZIP contents. The original v1.0.0 public release is unchanged until the new build is validated.
