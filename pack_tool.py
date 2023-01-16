from colorama import Fore, Back, Style, init
import time, os, shutil
import subprocess, shlex
from pathlib import Path
from shutil import which
import winreg
import itertools
init()

PROJECT_GIT_DIR   = str(Path(__file__).parent.resolve())

TARGET_BASE_DIR   = os.path.join(PROJECT_GIT_DIR, "Publish")
SOLUTION_PATH     = os.path.join(PROJECT_GIT_DIR, "Fo76ini\\Fo76ini.sln")
PROGRAM_BIN_DIR   = os.path.join(PROJECT_GIT_DIR, "Fo76ini\\bin\\Release")
EXECUTABLE_NAME   = "Fo76ini.exe"
EXECUTABLE_PATH   = os.path.join(PROGRAM_BIN_DIR, EXECUTABLE_NAME)
UPDATER_BIN_DIR   = os.path.join(PROJECT_GIT_DIR, "Fo76ini_Updater\\bin\\Release")
DEPENDENCIES_DIR  = os.path.join(PROJECT_GIT_DIR, "Additional files")
VERSION_PATH      = os.path.join(PROJECT_GIT_DIR, "VERSION")
SETUP_ISS_PATH    = os.path.join(PROJECT_GIT_DIR, "setup.iss")

VERSION = "x.x.x"

def get_binaries_path():
    return os.path.join(TARGET_BASE_DIR, "v" + VERSION)

def get_msbuild_path():
    """Attempts to run 'which', then reads the registry and returns the path to MSBuild.exe as string or None."""
    path = None

    if which("msbuild") is not None:
        return which("msbuild")

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

def build_updater():
    print("Building updater...")
    subprocess.run(shlex.split(f"\"{get_msbuild_path()}\" \"{SOLUTION_PATH}\" /p:Configuration=Release /t:Fo76ini_Updater"))
    copytree(UPDATER_BIN_DIR, get_binaries_path())

def build_app():
    print("Building app...")
    subprocess.run(shlex.split(f"\"{get_msbuild_path()}\" \"{SOLUTION_PATH}\" /p:Configuration=Release /t:Fo76ini"))
    copytree(PROGRAM_BIN_DIR, get_binaries_path())

def copy_additions():
    print("Copying additional files...")
    copytree(DEPENDENCIES_DIR, get_binaries_path())

def pack_release():
    print("Packing to v{0}.zip...".format(VERSION))
    os.system("{0} a \"{1}\" \"{2}\\*\"".format(get_7zip_path(), os.path.join(TARGET_BASE_DIR, "v" + VERSION + ".zip"), get_binaries_path()))
    # print("-----------------------------------------")
    # print("Packing to v{0}_src.zip...".format(VERSION))
    # time.sleep(0.25)
    # os.system("{0} a \"{1}\" \"{2}\\*\"".format(get_7zip_path(), os.path.join(target_dir, "v" + VERSION + "_src.zip"), os.path.join(PROJECT_GIT_DIR, "Fo76ini")))
    # print("-----------------------------------------")
    # print("Cleaning v{0}_src.zip...".format(VERSION))
    # time.sleep(0.25)
    # os.system("{0} d \"{1}\" .vs".format(get_7zip_path(), os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    # os.system("{0} d \"{1}\" bin".format(get_7zip_path(), os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    # os.system("{0} d \"{1}\" obj".format(get_7zip_path(), os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    # os.system("{0} d \"{1}\" packages".format(get_7zip_path(), os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    # print("-----------------------------------------")
    print("Done.")

# def extract_release():
#     print("Extracting release...")
#     target_dir = os.path.join(TARGET_BASE_DIR, "v" + VERSION)
#     os.system("{0} x \"{1}\" -r -o\"{2}\" *".format(get_7zip_path(), os.path.join(target_dir, "v" + VERSION + "_bin.zip"), os.path.join(target_dir, "v" + VERSION + "_bin")))

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
    subprocess.run(shlex.split("\"" + which("pandoc") + "\" --standalone --self-contained -f gfm \"What's new.md\" -o \"What's new.html\" --css=Pandoc/pandoc-style.css -H Pandoc/pandoc-header.html"))
    subprocess.run(shlex.split("\"" + which("pandoc") + "\" --standalone --self-contained -f gfm \"What's new.md\" -o \"What's new - Dark.html\" --css=Pandoc/pandoc-style-dark.css -H Pandoc/pandoc-header.html"))
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

if __name__ == "__main__":
    print("""-----------------------------------------
                Pack Tool""")

    mkdir(TARGET_BASE_DIR)

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
        print("-----------------------------------------\n" + warn_text + Fore.RESET, end="")
    else:
        print("-----------------------------------------\n" + Fore.GREEN + "All requirements found!\n" + Fore.RESET, end="")

    get_version()

    while True:
        print("-----------------------------------------")
        time.sleep(0.25)
        print(f"""{Fore.BLUE}Set version
{Fore.MAGENTA}(1){Fore.RESET} Set "VERSION" (current: {Fore.GREEN}{VERSION}{Fore.RESET})

{Fore.BLUE}Building
{Fore.MAGENTA}(2){Fore.RESET} Build app
{Fore.MAGENTA}(3){Fore.RESET} Pack app to *.zip
{Fore.MAGENTA}(4){Fore.RESET} Build setup

{Fore.BLUE}What's new.md
{Fore.MAGENTA}(5){Fore.RESET} Convert Markdown to HTML and RTF using Pandoc

{Fore.BLUE}Others
{Fore.MAGENTA}(6){Fore.RESET} Open target folder
{Fore.MAGENTA}(0){Fore.RESET} Exit (Ctrl+C)
-----------------------------------------""")
        try:
            i = input(">>> ").strip()
        except KeyboardInterrupt:
            print("""^C - Bye bye!
-----------------------------------------""")
            time.sleep(0.25)
            break

        if i == "1":
            set_version()
        elif i == "2":
            build_updater()
            build_app()
            copy_additions()
            use_rcedit()
        elif i == "3":
            pack_release()
        elif i == "4":
            update_inno()
            build_inno()
        elif i == "5":
            convert_md()
        elif i == "6":
            open_dir()
        elif i == "0" or i == "":
            print("""Bye bye!
-----------------------------------------""")
            time.sleep(0.25)
            break
        else:
            print("Input not recognized.")