#!/bin/bash

# To run this script on Windows, you require Cygwin, Git Bash, or WSL2.
# For the --path argument, you have to input something like this:
# Cygwin:   /cygdrive/c/Program Files (x86)/Steam/steamapps/common/Fallout76/Fallout76.exe
# Git Bash:          /c/Program Files (x86)/Steam/steamapps/common/Fallout76/Fallout76.exe
# WSL2:          /mnt/c/Program Files (x86)/Steam/steamapps/common/Fallout76/Fallout76.exe

# Credit: u/LinuxVersion on Reddit
# -> https://www.reddit.com/r/fo76/comments/om82q0/all_2832_ini_settings_recognized_by_the_game/
# -> https://pastebin.com/raw/rxuSq05A

function show_help () {
  echo "Small bash script to extract *.ini settings from the executable."
  echo ""
  echo "Usage:"
  echo "$ ./list-ini-values.sh --path <path-to-Fallout76.exe>"
  echo ""
  echo "Options:"
  echo "  -p or --path <path-to-Fallout76.exe>"
  echo "  -c or --comma-separated"
  echo "  -h or --help"
}

while [[ $# -gt 0 ]]; do
  case $1 in
    -p|--path)
      exe_path="$2"
      shift
      shift
      ;;
    -c|--comma-separated)
      comma_separated=1
      shift
      ;;
    -h|--help|-?)
      show_help
      exit 0
      ;;
    --)
      shift
      ;;
    -*|--*|*)
      echo "Unknown option $1"
      exit 1
      ;;
  esac
done

if [ $# -ne 0 ]; then
  echo "unknown option(s): $@"
  exit 1
fi

if [ -z "$exe_path" ]; then
  show_help
  exit 1
fi

if [ ! -f "$exe_path" ]; then
  echo "The path '$exe_path' does not exist or isn't a file."
  exit 1
fi

if [ "$comma_separated" = "1" ]; then
  grep -a -o "[abcfhirsu][iA-Z][a-zA-Z0-9_]\{2,\}:[A-Z][A-Za-z0-9_]\{2,\}" "$exe_path" | # Grab all strings that look sort of like this: uWorkshopLODRadius:Workshop
  sed 's/\(.*[^:]\):\(\w\+\)/\2\n\1/p' | # Separate each *.ini key and section by a newline
  sort |       # Sort alphabetically
  uniq |       # Remove duplicates
  head -c -1 | # Remove the last trailing newline
  tr '\n' ','  # Replace all newlines by comma_separated
else
  grep -a -o "[abcfhirsu][iA-Z][a-zA-Z0-9_]\{2,\}:[A-Z][A-Za-z0-9_]\{2,\}" "$exe_path" | # Grab all strings that look sort of like this: uWorkshopLODRadius:Workshop
  sed 's/\(.*[^:]\):\(\w\+\)/[\2] \1/p' | # Clean it up: "key:section" -> "[section] key"
  sort | # Sort alphabetically
  uniq   # Remove duplicates
fi