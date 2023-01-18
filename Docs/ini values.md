# Extracting *.ini values

The app ships with an "autocomplete.txt" file that contains all the *.ini sections and keys that can be extracted from the game's executable.

I made a small bash script for this. All that is needed to update the "autocomplete.txt" file is to run this:

```bash
$ bash ./list-ini-values.sh --path <path-to-Fallout76.exe> --comma-separated > ./Additional\ files/autocomplete.txt
```

You can also list all available *.ini keys in a human readable form:

```bash
$ bash ./list-ini-values.sh --path <path-to-Fallout76.exe>
```

If you want to run this script under Windows, you need either [Cygwin](https://www.cygwin.com/), [Git Bash](https://gitforwindows.org/) (which is often bundled with git anyway), or [WSL2](https://learn.microsoft.com/en-us/windows/wsl/). Pick one.

Credit goes it u/LinuxVersion on Reddit:
- https://www.reddit.com/r/fo76/comments/om82q0/all_2832_ini_settings_recognized_by_the_game/
- https://pastebin.com/raw/rxuSq05A
