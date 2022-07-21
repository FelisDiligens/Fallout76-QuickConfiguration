### What’s new in 1.10.2?

Hello everyone,

this is a small update with bug fixes.

I'm currently working on an update with lots of UI changes and decided to backport the bug fixes to v1.10.

Happy hunting,  
~ datasnake

---

**Full changelog**:  
_(bug fix backports from yet unreleased v1.11.0)_

- Replaced the awful 'FolderBrowserDialog' with a proper dialog.
  - This also fixes a bug where it's not possible to select the Xbox installation path.
- Fixed 'Import installed mods' again...
- Fixed Quick-Boy color tweak
- The state of the mod manager is now saved automatically upon closing
- Clears comments before merging with *.add.ini files
- Fixed: The tool wouldn't find the audio files for notifications when started with a shortcut, because it looked inside wrong directory.
- String files are detected properly now.
- Replaced TrackBar.ValueChanged by TrackBar.Scroll: Sliders should now no longer reset the values if they are exceeding the slider's range.
- Gallery: Fixed a bug that would crash the tool if the user tried to delete an image using the context menu after the tool has created a thumbnail for said image. Also, if deleting fails, it'll display an error message instead of crashing.
- Added missing messageboxes
- Deletes frozen archives when unfreezing them.
- Changed the displayed 'Rate limit reset' in Settings -> NexusMods from Daily to Hourly