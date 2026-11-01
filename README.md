# Lingam's Panning Tweak

A lightweight quality-of-life mod for **Vintage Story 1.22** that extends ordinary hand panning while preserving vanilla rewards and animations.

## Features

- **Pan beneath obstructions:** Collect pannable materials even when rock, dirt, or other blocks are above them.
- **Top-down collection:** When you target any block in a continuous vertical stack of pannable materials, one layer is collected from the highest pannable block in that stack.
- **Material-aware feedback:** While holding an empty pan and targeting a lower part of a stack, the block information display shows which material will be collected from above.
- **Vanilla-compatible approach:** Uses the game's existing pannable-material definitions rather than hardcoding a list of sand, gravel, and bony soil. Preserves the material type used for vanilla panning rewards and respects land claims.

The intent is to work with other appropriately defined pannable materials, although compatibility with every third-party mod cannot be guaranteed. Mods that directly change the vanilla pan's material-collection behavior may need additional testing.

## Installation

Download the mod ZIP from the [Vintage Story Mod Database](https://mods.vintagestory.at/) once published, place the ZIP in your Vintage Story **Mods** folder, and enable it in the Mod Manager. The mod is intended for both client and server use.

## Building from source

Requires the **.NET 10 SDK** and a local **Vintage Story 1.22** installation. The project references the game's `VintagestoryAPI.dll`, `VSSurvivalMod.dll`, and bundled `0Harmony.dll`; these game libraries are not redistributed here.

The included project file uses `%APPDATA%\Vintagestory` for the game install location. Adjust reference paths in `PanningMod.csproj` if your installation differs.

```powershell
dotnet build PanningMod.csproj -c Release
```

## Bug reports and suggestions

Please use [GitHub Issues](https://github.com/wesley947/LingamsPanningTweak/issues) for reproducible bugs, compatibility reports, or suggestions. Include your Vintage Story version and any relevant mods.

## Credits

Created and tested by **Lingam**, with AI assistance during development. This project is an optional gameplay tweak, not an official Vintage Story mod.
