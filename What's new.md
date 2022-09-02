### What's new in v1.11.4?

This update adds:
 - the server status of Fallout 76 to the home page.  
   This way, you can check if the game is online or in maintenance before you start it.
 - Depth of Field strength slider to the "Tweaks" page.
 - a notification that pops up if translations can be updated (opt-out).
 - minor changes.

---

### What's new in v1.11.3h1? - Hotfix 1

Fixed an issue where drag and drop into the mod list would fail if the mod list was empty.

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