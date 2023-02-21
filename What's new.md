### What's new in v1.12.4?

- The mod manager can now partially read *.ba2 files:
  - Added 'Tools -> Archive2 -> Display info about *.ba2 archive' button to the mod manager.
  - The preset of *.ba2 files get detected now, when imported.
- Changed the behavior of the mod manager slightly:
  - Interface files will now be separated into a 'Bundled - Interface.ba2'
  - Interface files will now be packed into a different preset. (Format: General, Compression: None)

*Unreleased*

---

### What's new in v1.12.3?

- Fixed "Backpack Visible" option
- Fixed some start-up crashes (when reading *.xml files)
- Updated some files: default *.ini files, autocomplete suggestions (Custom Tweaks)

*Released: Jan 19, 2023*

---

### What's new in v1.12.2?

Fixed the server status.

*Released: Oct 26, 2022*

---

### What's new in v1.12.1? - Hotfix

Hello everyone!

I'm sorry for the inconvenience, the tool shouldn't crash now.  
Sadly, the server status might not work for now. I'll look at it soon.

This update also fixes a few other bugs, see changelog.


Happy hunting,

~ FelisDiligens

**Changelog:**
<details>
<summary>Click to expand</summary>

- Fixed a bug where an HTML response (instead of a JSON response) from Bethesda's servers would crash the tool.
- Added missing messagebox "customIniFilesParsingError"
- The tool now displays a warning if the user enabled DPI scaling.
- Saves the config.ini directly after logging in to NexusMods, hopefully retaining the login information between restarts now.

</details>

*Released: Oct 25, 2022*

---

### What’s new in v1.12.0? - The dark mode update

Hello everyone,

this update adds two themes to the tool: light and dark.  
By default, it uses your system settings, but you can also manually select which theme you want to use.  
The dark mode isn't perfect and there were some elements I couldn't or didn't change.

I hope your eyes are now soothed with the dark mode. :)

Happy hunting,  
~ FelisDiligens

**Changelog:**
<details>
<summary>Click to expand</summary>

- Added dark and light mode which can be toggled in the App Settings.
  - Changed some UI elements in order to make them themable. (TrackBars/Sliders, GroupBoxes, TabControls, ListView, etc.)
  - Theming support probably comes with a small hit to performance.
  - Added separate loading animations and some images (b&w) for light and dark theme.
  - (added YAML parser "YamlDotNet" as a dependency)
- Bug fixes / Minor changes:
  - Fixed archives of removed mods not getting deleted, which resulted in junk *.ba2 files in the Data folder.
  - Fixed: Frozen mods now get deployed even if the mod folder is empty.
  - Fixed: Some tool tips weren't translatable.
  - Added NukaCrypt and Map76 web links.

</details>

*Released: Sep 25, 2022*

---

### What's new in v1.11.5?

This update mainly fixes the server status display.

Before:  
![Before](https://i.imgur.com/BHUhoCB.png)  

After:  
![After](https://i.imgur.com/tCUVSyD.png)

**Small changelog:**
<details>
<summary>Click to expand</summary>

- Fixed the server status display: Expected different response from server (e.g. "maintenance" instead of the actual "under_maintenance")
- Small QoL fix: The mod manager now remembers whether or not the user has collapsed the side panel.
- Updated 7z from version 19.00 to 22.01

</details>

*Released: Sep 13, 2022*

---

### What's new in v1.11.4?

This update adds:
 - the server status of Fallout 76 to the home page.  
   This way, you can check if the game is online or in maintenance before you start it.
 - Depth of Field strength slider to the "Tweaks" page.
 - a notification that pops up if translations can be updated (opt-out).
 - minor changes.

*Released: Sep 2, 2022*

---

### What's new in v1.11.3h1? - Hotfix 1

Fixed an issue where drag and drop into the mod list would fail if the mod list was empty.

*Released: Aug 28, 2022*

---

### What's new in v1.11.3?

This is a small update that
- changes the UI a bit,
- adds sensitivity sliders for the gamepad,
- adds an overall graphics quality setting,
- adds separate quality settings for textures, shadows, water, & volumetric lighting,
- and fixes a few bugs.

**Changelog:**
<details>
<summary>Click to expand</summary>

- Tweaks:
  - Controls: Added sensitivity sliders for the gamepad.
  - Graphics: Added texture quality preset (Low, Medium, High, Ultra).
  - Graphics: Added shadow quality preset (Low, Medium, High, Ultra).
  - Graphics: Added water shadow filter setting (Low, Medium, High).
  - Graphics: Added volumetric lighting quality setting (Low, Medium, High).
  - Graphics: Added overall graphics quality preset (Low, Medium, High, Ultra).
- Profiles:
  - Fixed a bug where creating and/or deleting profiles wouldn't save the changes. Therefore, after deleting a profile, it would still appear after restarting the tool.
- Home page:
  - Added web links.
  - "What's new" is now accessible through a button click.
- App Settings:
  - Removed "Hide What's new" option.
- Gallery:
  - Should search through the PTS screenshot folder for images and display them now.
- Translations:
  - Changed the font for titles in Japanese translation to Roboto Condensed.
  - Fixed a bug that would crash the tool if a translated resource (\*.rtf, \*.html) couldn't be accessed. (Either because the file is locked or access is denied)
- Windows 7 and 8.1:
  - The Info tab in Tweaks doesn't display the embedded webbrowser anymore. Instead, there will be a button to open the info document in the user's preferred browser.  
    (This is because I couldn't get the embedded webbrowser to work on older Windows versions. Windows 10 and 11 aren't affected)

</details>

*Released: Aug 25, 2022*

---

### What's new in v1.11.2?

This is another small update to address some bugs.

**Changelog:**
<details>
<summary>Click to expand</summary>

- App Settings:
  - Added a link to the app settings that opens the profile editing screen.
  - Added an option to disable automatic *.ini backups to the app settings.
  - Added an option to disable notifications (popups) to the app settings.
- Mod Manager:
  - Dragging and dropping mods (archives or folders) into the list installs them at the correct position (where the cursor is) instead of at the end of the list now.
  - Improved the comparison of versions in the mod manager.  
    This should fix the issue where the mod manager displays available updates even if the latest/newer version is installed.
  - Fixed a bug that would crash the mod manager when updating mod information using the NexusMods API.
  - Added another warning to the mod manager's side panel, if no (valid) files are found for packing.
  - Improved packing of bundled archives: junk files are now ignored. Should reduce errors.
- General:
  - Fixed a bug where invalid characters in (user-defined) paths were crashing the tool. They get sanitized now.

</details>

*Released: 18 Aug 2022*

---

### What's new in v1.11.1?

This is a small update to address some bugs.

**Changelog:**
<details>
<summary>Click to expand</summary>

- The textbox for the resource list in the mod manager has scrollbars now.
- Fix: The Quick-Boy color wouldn't be applied if values in the Fallout76Custom.ini override them.
- Fixed small issue that would prevent the tool from downloading translations on first start.
- Translations:
  - The font for the titles changes depending on the selected language. (Russian uses Roboto, Chinese uses Microsoft JhengHei)
- Minor changes

</details>

*Released: 30 Jul 2022*

---

### What’s new in v1.11.0? - The "fresh coat of paint" update

> **If you do not like the changes, you can download v1.10 from NexusMods or GitHub.**

Hello everyone,

this update is a rather large one - at least in terms of UI changes.  
I decided to rearrange everything and add a sidebar for navigation.

I tested almost every tweak and changed/removed old tweaks as well as adding a few new ones.  
The mod manager has two new options. Also, I fixed some smaller bugs.
Just explore a little, if you like to.

As always, you can read the changelog below.


Happy hunting,

~ datasnake

**Changelog:**
<details>
<summary>Click to expand</summary>

- General:
  - Most notable change: Added a side navigation that replaces the top panel, the bottom status panel, and the tabs.
  - Added a "Hero" banner to the "Home" page
  - Moved "Tweaks" into their own page
  - Removed "Settings" window; moved "Settings", "Profiles", and "NexusMods" into their own page
  - Reworked the profile manager
  - Added line numbers, syntax highlighting, autocompletion and hotkeys to the "Custom" page's textbox
  - Replaced the awful `FolderBrowserDialog` with a proper dialog that let's you choose a folder more comfortably.
- Tweaks:
  - Tweaks are now color-coded
    - Added Info about color-codes and tool tips
  - Reworked tweaks:
    - Added some missing tweaks from the ingame settings
    - Added Screen Space Reflections and Blood Splatter to Graphics tweaks
      - Added fix for black/invisible water
    - Removed some tweaks that didn't do anything
    - Changed some tweaks
  - Added FOV preview
  - Removed the "Danger Zone"
  - *.ini files are parsed differently now:
    - Comments can now be in-line and begin with `";"` (semicolon) or `"#"` (hash)
      - This might break the s76UserName and s76Password text fields.
- Pip-Boy:
  - Added a few more Pip-Boy color presets
  - Added HEX codes to Pip-Boy tab
  - Fixed Quick-Boy color not applying ingame
- Profiles:
  - You can now change the path where the *.ini files are stored.
- Mod manager:
  - Fixed: "Import installed mods" importing already managed mods.
  - Added an option to create symlinks when deploying. (Experimental feature)
  - Added an option to put bundled archives last in the load order.
  - Placed "Notes" under "Installation options" in mod manager's side panel
  - Added a button to open the folder of a mod in mod manager's side panel
- Minor changes / fixes
  - Added missing messagebox strings when you picked the wrong game path.
  - Added missing messagebox strings when you delete photos in the gallery.
  - Made some UI elements that were previously untranslatable, translatable.
  - When picking the game path, you now browse for the folder instead of the *.exe file.
  - and a few more.
- Removed backwards-compatibility...
  - ... to v1.8's Mod Manager
  - ... to v1.8's Profiles
- Known issues:
  - The scroll whell on Windows 7 doesn't always work properly due to how focus works in older Windows versions.
  - If a password written into [Login]s76Password contains `";"` or `"#"`, it will be truncated.

</details>

*Released: 25 Jul 2022*