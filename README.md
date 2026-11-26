# Lingam's Panning Tweak

A lightweight quality-of-life mod for **Vintage Story** that improves panning and adds **Wading Stability**, while preserving vanilla panning rewards and animations. The 1.22.x and 1.23.0-pre.2 builds are distributed separately.

## Features

- **Pan beneath obstructions:** Collect pannable materials even when rock, dirt, or other blocks are above them.
- **Top-down collection:** When you target any block in a continuous vertical stack of pannable materials, one layer is collected from the highest pannable block in that stack.
- **Material-aware feedback:** While holding an empty pan and targeting a lower part of a stack, the block information display shows which material will be collected from above.
- **Wading Stability (new in 1.1.0-pre.2):** Automatically prevents horizontal current drift while standing or walking on solid ground in flowing water with your eyes above water. Swimming, jumping, and underwater currents remain vanilla. Use `/panning drift on` to restore vanilla current drift; `/panning drift off` to enable stability; `/panning drift` to check status. Saved per-player preferences are preserved.
- **Vanilla-compatible approach:** Uses the game's existing pannable-material definitions rather than hardcoding a list of sand, gravel, and bony soil. Preserves the material type used for vanilla panning rewards and respects land claims.

The intent is to work with other appropriately defined pannable materials, although compatibility with every third-party mod cannot be guaranteed. Mods that directly change the vanilla pan's material-collection behavior may need additional testing.

## Installation

Download a build matching **your exact Vintage Story version** (the 1.23.0-pre.2 ZIP is *not* for 1.22.x), place the ZIP in your Vintage Story **Mods** folder, and enable it in the Mod Manager. The mod is intended for both client and server use.

## Building from source

Requires the **.NET 10 SDK** and a local **Vintage Story installation matching the build target**. The project references the game's `VintagestoryAPI.dll`, `VSSurvivalMod.dll`, and bundled `0Harmony.dll`; these game libraries are not redistributed here.

The included project file uses `%APPDATA%\Vintagestory` for the game install location. Set `VINTAGE_STORY` to another path if your installation differs.

```powershell
dotnet build PanningMod.csproj -c Release
```

## Bug reports and suggestions

Please use [GitHub Issues](https://github.com/wesley947/LingamsPanningTweak/issues) for reproducible bugs, compatibility reports, or suggestions. Include your Vintage Story version and any relevant mods.

## Credits

Created and tested by **Lingam**, with AI assistance during development. This project is an optional gameplay tweak, not an official Vintage Story mod.

## License

MIT — see [LICENSE](LICENSE).
