from colorama import Fore, Back, Style, init
import os, shutil
import subprocess, shlex
from pathlib import Path
from shutil import which
import winreg
import itertools
import argparse
init()

PROJECT_GIT_DIR   = str(Path(__file__).parent.resolve())

TARGET_BASE_DIR   = os.path.join(PROJECT_GIT_DIR, "Publish")
SOLUTION_PATH     = os.path.join(PROJECT_GIT_DIR, "Fo76ini\\Fo76ini.sln")
PROGRAM_BIN_DIR   = os.path.join(PROJECT_GIT_DIR, "Fo76ini\\bin\\")
EXECUTABLE_NAME   = "Fo76ini.exe"
EXECUTABLE_PATH   = os.path.join(PROGRAM_BIN_DIR, "Release", EXECUTABLE_NAME)
UPDATER_BIN_DIR   = os.path.join(PROJECT_GIT_DIR, "Fo76ini_Updater\\bin\\")
DEPENDENCIES_DIR  = os.path.join(PROJECT_GIT_DIR, "Additional files")
VERSION_PATH      = os.path.join(PROJECT_GIT_DIR, "VERSION")
SETUP_ISS_PATH    = os.path.join(PROJECT_GIT_DIR, "setup.iss")

VERSION = "x.x.x"

def get_binaries_path():
    return os.path.join(TARGET_BASE_DIR, "v" + VERSION)

def get_msbuild_path():
    """Attempts to run 'which', then check common paths, and if all else fails, reads the registry and returns the path to MSBuild.exe as string or None."""
    path = None

    if which("msbuild") is not None:
        return which("msbuild")

    for drive in ["C:", "D:"]:
        if os.path.isfile(drive + "\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"):
            return drive + "\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"
        elif os.path.isfile(drive + "\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"):
            return drive + "\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"
        elif os.path.isfile(drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"):
            return drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"
        elif os.path.isfile(drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"):
            return drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"
        elif os.path.isfile(drive + "\\Program Files\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"):
            return drive + "\\Program Files\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"
        elif os.path.isfile(drive + "\\Program Files\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"):
            return drive + "\\Program Files\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"
        elif os.path.isfile(drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"):
            return drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"
        elif os.path.isfile(drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"):
            return drive + "\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\amd64\\MSBuild.exe"

    # https://stackoverflow.com/questions/328017/path-to-msbuild
    with winreg.ConnectRegistry(None, winreg.HKEY_LOCAL_MACHINE) as reg:
        with winreg.OpenKey(reg, "SOFTWARE\\Microsoft\\MSBuild\\ToolsVersions\\4.0") as key:
            try:
                for i in itertools.count(start = 0, step = 1):
                    name, value, type = winreg.EnumValue(key, i)
                    if name == "MSBuildToolsPath" and type == winreg.REG_SZ:
                        path = value
                        break
            except OSError:
                # No more values
                pass

    if path is not None:
        path = os.path.join(path, "MSBuild.exe")
        if os.path.isfile(path):
            return path

    return None

def get_7zip_path():
    sevenzip = which("7z")
    if sevenzip is not None:
        return sevenzip

    sevenzip_alt = which("7za")
    if sevenzip_alt is not None:
        return sevenzip_alt

    return None

def get_version():
    global VERSION
    try:
        with open(VERSION_PATH, "r") as f:
            VERSION = f.read().strip()
    except:
        print(Fore.RED + "ERROR: Couldn't read VERSION" + Fore.RESET)

def set_version():
    global VERSION
    try:
        VERSION = input("VERSION: ")
        with open(VERSION_PATH, "w") as f:
            f.write(VERSION + "\n")
        print("Version set.")
    except KeyboardInterrupt:
        print("\nAbort.")
        return

def build_updater(debug = False):
    print("Building updater...")
    configuration = "Debug" if debug else "Release"
    subprocess.run(shlex.split(f"\"{get_msbuild_path()}\" \"{SOLUTION_PATH}\" /p:Configuration={configuration} /t:Fo76ini_Updater"))
    if debug:
        copytree(UPDATER_BIN_DIR + configuration, PROGRAM_BIN_DIR + configuration)
    else:
        copytree(UPDATER_BIN_DIR + configuration, get_binaries_path())

def build_app(debug = False):
    print("Building app...")
    configuration = "Debug" if debug else "Release"
    subprocess.run(shlex.split(f"\"{get_msbuild_path()}\" \"{SOLUTION_PATH}\" /p:Configuration={configuration} /t:Fo76ini"))
    if not debug:
        copytree(PROGRAM_BIN_DIR + "Release", get_binaries_path())

def copy_additions(debug = False):
    print("Copying additional files...")
    if debug:
        copytree(DEPENDENCIES_DIR, PROGRAM_BIN_DIR + "Debug")
    else:
        copytree(DEPENDENCIES_DIR, get_binaries_path())

def pack_release():
    print("Packing to v{0}.zip...".format(VERSION))
    os.system("{0} a \"{1}\" \"{2}\\*\"".format(get_7zip_path(), os.path.join(TARGET_BASE_DIR, "v" + VERSION + ".zip"), get_binaries_path()))
    print("Done.")

def use_rcedit():
    print("Setting executable version to '{0}'...".format(VERSION))
    os.system("{0} \"{1}\" --set-file-version {2} --set-product-version {2}".format(which("rcedit"), EXECUTABLE_PATH, VERSION))
    os.system("{0} \"{1}\" --set-file-version {2} --set-product-version {2}".format(which("rcedit"), os.path.join(get_binaries_path(), EXECUTABLE_NAME), VERSION))

def update_inno():
    print("Changing version number in setup.iss ...")
    content = ""
    with open(SETUP_ISS_PATH, "r") as f:
        for line in f:
            if line.startswith("#define ProjectVersion"):
                line = "#define ProjectVersion \"" + VERSION + "\"\n"
                print("Line changed: " + line, end="")
            if line.startswith("#define MyAppExeName"):
                line = "#define MyAppExeName \"" + EXECUTABLE_NAME + "\"\n"
                print("Line changed: " + line, end="")
            if line.startswith("#define ProjectGitDir"):
                line = "#define ProjectGitDir \"" + PROJECT_GIT_DIR.rstrip("\\") + "\"\n"
                print("Line changed: " + line, end="")
            #if line.startswith("#define ProjectPackTargetDir"):
            #    line = "#define ProjectPackTargetDir \"" + TARGET_BASE_DIR.rstrip("\\") + "\"\n"
            #    print("Line changed: " + line, end="")
            content += line
    with open(SETUP_ISS_PATH, "w") as f:
        f.write(content)

def build_inno():
    print("Building setup using ISCC...")
    subprocess.run(shlex.split("\"" + which("iscc") + "\" \"" + SETUP_ISS_PATH + "\""))

def convert_md():
    print("Converting Markdown to HTML and RTF")
    subprocess.run(shlex.split("\"" + which("pandoc") + "\" --standalone --self-contained -f gfm \"What's new.md\" -o \"whatsnew.html\" --css=Pandoc/pandoc-style.css -H Pandoc/pandoc-header.html"))
    subprocess.run(shlex.split("\"" + which("pandoc") + "\" --standalone --self-contained -f gfm \"What's new.md\" -o \"whatsnewdark.html\" --css=Pandoc/pandoc-style-dark.css -H Pandoc/pandoc-header.html"))
    subprocess.run(shlex.split("\"" + which("pandoc") + "\" --standalone \"What's new.md\" -o \"What's new.rtf\""))

def open_dir():
    if os.path.exists(TARGET_BASE_DIR):
        os.system("explorer.exe \"{0}\"".format(TARGET_BASE_DIR))
    else:
        print("ERROR: Path does not exist.")

# https://stackoverflow.com/a/7550424
def mkdir(newdir):
    """works the way a good mkdir should :)
        - already exists, silently complete
        - regular file in the way, raise an exception
        - parent directory(ies) does not exist, make them as well
    """
    if os.path.isdir(newdir):
        pass
    elif os.path.isfile(newdir):
        raise OSError("a file with the same name as the desired " \
                      "dir, '%s', already exists." % newdir)
    else:
        head, tail = os.path.split(newdir)
        if head and not os.path.isdir(head):
            mkdir(head)
        if tail:
            os.mkdir(newdir)

# https://stackoverflow.com/a/7550424
def copytree(src, dst, symlinks=False):
    """Recursively copy a directory tree using copy2().

    The destination directory must not already exist.
    If exception(s) occur, an Error is raised with a list of reasons.

    If the optional symlinks flag is true, symbolic links in the
    source tree result in symbolic links in the destination tree; if
    it is false, the contents of the files pointed to by symbolic
    links are copied.

    XXX Consider this example code rather than the ultimate tool.

    """
    names = os.listdir(src)
    mkdir(dst)
    errors = []
    for name in names:
        srcname = os.path.join(src, name)
        dstname = os.path.join(dst, name)
        try:
            if symlinks and os.path.islink(srcname):
                linkto = os.readlink(srcname)
                os.symlink(linkto, dstname)
            elif os.path.isdir(srcname):
                copytree(srcname, dstname, symlinks)
            else:
                shutil.copy2(srcname, dstname)
            # XXX What about devices, sockets etc.?
        except (IOError, os.error) as why:
            errors.append((srcname, dstname, str(why)))
        # catch the Error from the recursive copytree so that we can
        # continue with other files
        except Exception as err:
            errors.extend(err.args[0])
    try:
        shutil.copystat(src, dst)
    except WindowsError:
        # can't copy file access times on Windows
        pass

def run_interactive():
    print("""-----------------------------------------
                Pack Tool""")

    warn_text = get_warn_text()
    if warn_text:
        print("-----------------------------------------\n" + warn_text + Fore.RESET, end="")
    else:
        print("-----------------------------------------\n" + Fore.GREEN + "All requirements found!\n" + Fore.RESET, end="")

    while True:
        print("-----------------------------------------")
        print("You can also use command line arguments!\nSee: " + Fore.MAGENTA + "$ " + Fore.BLUE + "python pack_tool.py --help" + Fore.RESET)
        print("-----------------------------------------")
        print(f"""{Fore.BLUE}Set version
{Fore.MAGENTA}(1){Fore.RESET} Set "VERSION" (current: {Fore.GREEN}{VERSION}{Fore.RESET})

{Fore.BLUE}Building
{Fore.MAGENTA}(2){Fore.RESET} Build app (Debug)
{Fore.MAGENTA}(3){Fore.RESET} Build app (Release)
{Fore.MAGENTA}(4){Fore.RESET} Pack app to *.zip
{Fore.MAGENTA}(5){Fore.RESET} Build setup

{Fore.BLUE}What's new.md
{Fore.MAGENTA}(6){Fore.RESET} Convert Markdown to HTML and RTF using Pandoc

{Fore.BLUE}Others
{Fore.MAGENTA}(7){Fore.RESET} Open target folder
{Fore.MAGENTA}(0){Fore.RESET} Exit (Ctrl+C)
-----------------------------------------""")
        try:
            i = input(">>> ").strip()
        except KeyboardInterrupt:
            print("""^C - Bye bye!
-----------------------------------------""")
            break

        if i == "1":
            set_version()
            # use_rcedit()
        elif i == "2":
            build_updater(debug=True)
            build_app(debug=True)
            copy_additions(debug=True)
        elif i == "3":
            build_updater()
            build_app()
            copy_additions()
            use_rcedit()
        elif i == "4":
            pack_release()
        elif i == "5":
            update_inno()
            build_inno()
        elif i == "6":
            convert_md()
        elif i == "7":
            open_dir()
        elif i == "0" or i == "":
            print("""Bye bye!
-----------------------------------------""")
            break
        else:
            print("Input not recognized.")

def run_args(args):
    if args.set_version:
        set_version()
        # use_rcedit()
    if args.build_debug:
        build_updater(debug=True)
        build_app(debug=True)
        copy_additions(debug=True)
    if args.build:
        build_updater()
        build_app()
        copy_additions()
        use_rcedit()
    if args.pack:
        pack_release()
    if args.build_setup:
        update_inno()
        build_inno()
    if args.whatsnew:
        convert_md()

def get_warn_text():
    warn_text = ""
    if not os.path.exists(PROJECT_GIT_DIR):
        warn_text += Fore.YELLOW + "WARN: Project folder doesn't exist!\n"
    if not os.path.isdir(os.path.join(PROJECT_GIT_DIR, "Fo76ini")):
        warn_text += Fore.YELLOW + "WARN: " + Fore.RESET + "\"Fo76ini\" folder doesn't exist!\n      Please run the script within the git repo folder."
    if which("rcedit") is None:
        warn_text += Fore.YELLOW + "WARN: " + Fore.RESET + "rcedit not found!\n"
    if get_7zip_path() is None:
        warn_text += Fore.YELLOW + "WARN: " + Fore.RESET + "7-Zip not found!\n"
    if which("iscc") is None:
        warn_text += Fore.YELLOW + "WARN: " + Fore.RESET + "ISCC (Inno Setup Compiler) not found!\n"
    if which("pandoc") is None:
        warn_text += Fore.YELLOW + "WARN: " + Fore.RESET + "Pandoc not found!\n"
    if get_msbuild_path() is None:
        warn_text += Fore.YELLOW + "WARN: " + Fore.RESET + "MSBuild not found!\n"

    if warn_text:
        warn_text += Fore.YELLOW + "\nBuilding might fail if requirements are missing.\nMake sure you installed them properly and added them to your PATH.\n\nYou can install most of them with scoop like so:\n> " + Fore.BLUE + "scoop install 7zip git rcedit inno-setup pandoc\n"

    return warn_text

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description='Helper script for building Fallout 76 Quick Configuration')
    parser.add_argument('-v', '--set-version', help='set the current version', required=False, action='store_true')
    parser.add_argument('-b', '--build', help='build the app and updater', required=False, action='store_true')
    parser.add_argument('-d', '--build-debug', help='build the app and updater (Debug configuration)', required=False, action='store_true')
    parser.add_argument('-p', '--pack', help='pack the app into a zip archive', required=False, action='store_true')
    parser.add_argument('-s', '--build-setup', help='build the setup', required=False, action='store_true')
    parser.add_argument('-w', '--whatsnew', help='update the "What\'s new?" files', required=False, action='store_true')
    args = parser.parse_args()

    mkdir(TARGET_BASE_DIR)
    get_version()

    args_list = [args.build_debug, args.build, args.build_setup, args.pack, args.set_version, args.whatsnew]
    #if args_list.count(True) > 1:
    #    print("ERROR: Only one argument allowed")
    if args_list.count(True) >= 1:
        run_args(args)
    else:
        run_interactive()