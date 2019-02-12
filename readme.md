# Flashpoint-Curator
A tool for idiot-proofing the curation process for [BlueMaxima's Flashpoint](http://bluemaxima.org/flashpoint/). Curation requires games to be organized in a certain way, and specific metadata and images to be included. This tool provides an easy to use GUI to make the process easier and faster.

:warning: This tool will not be maintained. Instead, its features will be merged into [XXLuigiMario's FlashpointCC tool](https://github.com/FlashpointProject/FlashpointCC). I only put this here for archival purposes, and because enough demand was shown for it.

## Requirements
- Microsoft .NET Framework 2.0 or higher ([Link](https://www.microsoft.com/en-us/download/details.aspx?id=6523))

## How to use
Fill out the fields. They should be self-explanatory, but it's best to follow the practices set forth by the [Curation Format](http://bluemaxima.org/flashpoint/datahub/CurationFormat).

**Not documented in the tool:** You can also drag-and-drop an image into the Logo/Screenshot Preview boxes.

## :warning: Known Issues
- Unicode directories are not written properly to the ZIP file. Might be caused by [SharpZipLib](http://icsharpcode.github.io/SharpZipLib/)
- ZIP files have issues when replacing/updating files within, causing them to duplicate sometimes within the same location. [I'm not kidding](https://i.imgur.com/l46Z3qM.png). This has only been observed in WinRAR, and I haven't bothered to check other tools. As far as I'm aware, I'm closing the files properly, but it wasn't a big priority to fix this issue as the tool was to be deprecated. Might also be caused by [SharpZipLib](http://icsharpcode.github.io/SharpZipLib/), but unsure. To work around it, just extract the file first, delete it from the ZIP, and then re-add it after any modifications.
- Screen capturing is hard-coded to look for Flash player. If you want to capture screens for another technology, you'll have to edit the code.
- Crop feature is not implemented
- The tool was written with [SharpDevelop 3.2.0.5505 Portable](https://portableapps.com/node/23365) ([Archived download](https://web.archive.org/web/20110222100551/devbar.de/index.php/downloads/)). Editing it with Visual Studio might give some random warnings/errors, but shouldn't be too hard to fix. I provided the links to the exact IDE used just for the sake of convenience.

## Contributing
If you (for whatever reason) decide to make changes, I could take a look and merge them in. However, I encourage contribution efforts to go towards [XXLuigiMario's FlashpointCC tool](https://github.com/FlashpointProject/FlashpointCC).