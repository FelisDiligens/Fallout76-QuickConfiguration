# Fundamentals: Understanding what the app does

The app is essentially split into two concerns: The configuration and the modding part.

## Configuration

The app loads the game's configuration from `%userprofile%\Documents\My Games\Fallout 76\*.ini`

The \*.ini file prefix is the same as the executable name (without the extension) of the game.  
For the Steam version, that would be `Fallout76` and for the Xbox version, that would be `Project76`.

The \*.ini file suffixes are:
- "" - Defaults?
- "`Prefs`" - The in-game settings
- "`Custom`" - The game engine reads this file but doesn't modify it. Whether or not the values in this file take precedence over the values in `Fallout76Prefs.ini` is hit or miss.

The keys in the \*.ini files seem to follow the [Hungarian Notation](https://en.wikipedia.org/wiki/Hungarian_notation):

| Prefix    | Type of value                             |
| --------- | ----------------------------------------- |
| `b`       | Boolean (`0` for `false`, `1` for `true`) |
| `c`       | Character (?)                             |
| `d`       | Double-precision float (?)                |
| `f`       | Floating-point number                     |
| `i`       | Integer                                   |
| `s`       | String                                    |
| `u`, `ui` | Unsigned integer                          |

Sometimes these prefixes are capitalized. (Seems random)

All recognized section and key names can be extracted from the game's executable.

## Modding

Since Bethesda hasn't released the Creation Kit for Fallout 76 yet (and probably never will, I presume), the only mods that can be made are:
- Mods that replace assets, such as textures, sfx, strings, etc.
- Mods that extend the HUD / UI using Shockwave Flash.
- Mods that inject code into the game's executable or it's libraries, thereby modifing or extending functionality (see [SFE](https://www.nexusmods.com/fallout76/mods/287))

### Replacing assets

Assets are packed into a proprietary archive format developed by BGS for their engine. Read more here: https://stepmodifications.org/wiki/Guide:Archive2

Fallout 4's Creation Kit includes a copy of Archive2, which can be used to pack archives that also work in Fallout 76.  
These \*.ba2 archives can then be placed into the game's directory, under the `Data` folder.  
In order for the game to load these newly made *.ba2 archives and override any previously loaded asset, we have to modify `Fallout76Prefs.ini`, like so:
```
[Archive]
sResourceArchive2List=YourBA2FileHere,CommaSeparated
```

However, to the confusion of many users, there are multiple keys that are recognized by the game's engine:
- `sResourceIndexFileList` (which this mod manager uses)
- `sResourceArchive2List` (which a lot of people use)
- `sResourceArchiveMisc` (apparently "can load any mod except for texture and animation mods")
- and many more...

`sResourceIndexFileList` and `sResourceArchive2List` seem to work for most people, most of the time.

All that the mod manager does, is packing loose assets using Archive2 and adding these files to the list in the \*.ini file. (As well as saving some meta data about the mod)

#### Types of assets

| Asset type   | File type and extension                        | Archive2 format | Archive2 compression |
| ------------ | ---------------------------------------------- | --------------- | -------------------- |
| Mesh         | NetImmerse File (\*.nif)                       | General         | Default              |
| Animation    | \*.hkx                                         | General         | Default              |
| Texture      | DirectDraw Surface (\*.dds)                    | DDS             | Default              |
| Material     | \*.bgsm, \*.bgem                               | General         | Default              |
| HUD/UI       | Shockwave Flash (\*.swf)                       | General         | None                 |
| SFX/Music    | XAudio2 file (\*.xwm)                          | General         | None                 |
| Voice        | \*.fuz                                         | General         | None                 |
| Lip sync     | \*.lip                                         | General         | None                 |
| Localization | \*.dlstrings, \*.ilstrings, \*.strings, \*.txt | General         | None                 |

#### \*.ba2 file format

If you're interested in the structure of a \*.ba2 file, see [\*.ba2 format](./ba2format.md).
