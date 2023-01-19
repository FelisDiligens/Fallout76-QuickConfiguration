# Project Structure

The project structure is admittedly a little confusing and could be better.  
Here's an overview:

- [Project Structure](#project-structure)
  - [Project root](#project-root)
  - [Fo76ini solution](#fo76ini-solution)
  - [Files downloaded by the tool](#files-downloaded-by-the-tool)
    - [From GitHub `master` repository:](#from-github-master-repository)
    - [From GitHub releases:](#from-github-releases)
    - [Using the GitHub API:](#using-the-github-api)
    - [From felisdiligens.github.io:](#from-felisdiligensgithubio)

## Project root

```
📁 .
├── 📁 Docs                    ⇨ Documentation
│
├── 📁 Additional files        ⇨ Additional files that need to be copied to the bin folder.
├── 📁 Fo76ini
│   └── 📝 Fo76ini.sln         ⇨ Main solution. Open this.
├── 📁 Fo76ini_Updater
│   └── 📝 Fo76ini_Updater.sln ⇨ Solution for the auto-updater.
├── 📁 ObjectListView          ⇨ Extends the built-in ListView control. Used in the Mod Manager.
│
├── 📝 VERSION                 ⇨ Contains the current version.
├── 📝 What's new.md           ⇨ What's new? - Changelogs, etc.
├── 🐍 pack_tool.py            ⇨ Python script that is used to prepare and pack the release.
└── ...
```

## Fo76ini solution

```
📁 ./Fo76ini
├── 📁 Controls                ⇨ Holds custom UserControls
├── 📁 Forms                   ⇨ Holds Forms and UserControls used in a specific Form
│   ├── 📁 FormMain            ⇨ The main form
│   │   └── 📁 Views           ⇨ All the views of the main form
│   ├── 📁 FormMods            ⇨ The "Mod Manager" form
│   ├── 📁 FormWelcome         ⇨ Form that opens when the tool is launched for the first time.
│   ├── 📁 FormExceptionDialog ⇨ Opened when an unhandled exception occures.
│   ├── 📁 FormIniError        ⇨ Opened when the *.ini files can't be parsed.
│   │
│   ├── 📁 FormProfiles        ⇨ Unused.
│   ├── 📁 FormSettings        ⇨ Unused.
│   ├── 📁 FormWhatsNew        ⇨ Unused.
│   └── 📁 FormTextPrompt      ⇨ Custom messageboxes, unused.
│
├── 📁 Ini                     ⇨ Ini parsing and handling (load, change, save, etc.)
├── 📁 Interface               ⇨ Translation, theming, and other interface related code
├── 📁 Mods                    ⇨ Loading, saving, and manipulating mods.
├── 📁 NexusAPI                ⇨ Accessing the NexusMods API and storing data.
├── 📁 Profiles                ⇨ Loading, saving, and editing profiles.
├── 📁 Properties              ⇨ Project settings and resources.resx
├── 📁 Resources               ⇨ Contains images, icons, fonts, text (html/rtf), etc.
├── 📁 Tweaks                  ⇨ *.ini tweaks (=game settings) sorted into subdirectories
├── 📁 Utilities               ⇨ Any class that can be used everywhere and doesn't have it's own place.
├── 📁 languages               ⇨ Translations that are downloaded by the tool through GitHub.
│
├── 📝 Configuration.cs        ⇨ Easily accessible Props for the tool's configuration.
├── 📝 Initialization.cs       ⇨ Init: Creating folders, reading configuration, etc.
├── 📝 Program.cs              ⇨ Program entry point (static void Main).
├── 📝 Shared.cs               ⇨ Containing constants, such as version, user agent, or URLs.
└── ...
```

## Files downloaded by the tool

The tool downloads or requests information from GitHub's API for various reasons.

### From GitHub `master` repository:

**Checking for updates, "What's new", and translations:**  
```
📁 .
├── 📝 VERSION                 ⇨ Downloaded on startup to check for updates.
├── 📝 What's new.rtf          ⇨ Downloaded and displayed on versions prior to v1.11.
│
└── 📁 Fo76ini
    └── 📁 languages           ⇨ *.zip archives containing the translations.
        ├── 📝 list.iso.txt    ⇨ List of available translations for download.
        └── 🗃️ xx-XX.zip       ⇨ Translations
```

### From GitHub releases:

**Updates:**  
Any file that follows the `vx.xx.x_bin.zip` naming scheme. Downloaded and extracted by the auto-updater.

### Using the GitHub API:

**Checking for updates to translations (as of v1.11.4):**  
Checks if any commit to the path `./Fo76ini/languages` has happened since the last update to the translations.

### From felisdiligens.github.io:
Displays [felisdiligens.github.io/Fo76ini/What's new.html](https://felisdiligens.github.io/Fo76ini/What's%20new.html) and [/What's new - Dark.html](https://felisdiligens.github.io/Fo76ini/What's%20new%20-%20Dark.html) in a web browser control.

> These files are now symlinks that point to 'whatsnew.html' and 'whatsnewdark.html'