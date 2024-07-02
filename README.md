## OPEN MOD MANAGER // UNDREW EDIT
UnDrew: This is a **fork of [mcu8](https://github.com/mcu8)'s [OpenModManager](https://github.com/mcu8/OpenModManager)**, where I can make my personal edits (mostly just adding support for new tags for now).
Something I learned the hard way: Some packages, like CUFramework, are not available from the get-go. You have to go to Project > Manage NuGet Packages, where you can download everything that's missing. Keep this in mind if you want to fork this or the og OMM with your own changes!

![Screenshot](https://hat.ovh/omm.png)

What is this? Flying boat?
---
That's the Mod Manager but fully rewritten from scratch with the new features:
 - Resizable window
 - Embedded console
 - "Mafia Punch:tm:" button (for killing editor when it not respond)
 - Batch-building more than one mod at once
 - Fully dark themed
 - Better Asset Replacements editor
 - Mod configuration editor
 - Clipbook generator (from gif)
 - Asset exporter (works with SoundNodeWaves and Texture2D)
 - Custom workshop uploader with advanced features
 - Search bar
 - Script watcher (it auto compile scripts when you modify something in it) - disabled by default
 - Mod list context menu
 ... and more!

You can find a ready to run version on the [Releases](https://github.com/mcu8/OpenModManager/releases/latest) tab
---
Now supports mod uploading via Steamworks API (no more int32 issue)!
Works only with the Steam release of the game and 64-bit operating systems (cuz the game is 64-bit anyway).
Requires .NET Framework v4.0 (you probably have it already installed if you are used official Modding Tools before)

Installation
---
Download latest release from the [Releases](https://github.com/mcu8/OpenModManager/releases/latest) tab, extract it to some folder and run the "ModdingTools.exe" executable.

Building
---
Clone the repository and open it in the Visual Studio 2019 (or newer).

Disclaimer
---
This tool is an unofficial tool and is not associated with Gears for Breakfast
