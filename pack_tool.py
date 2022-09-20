from colorama import Fore, Back, Style, init
import time, os, shutil
import subprocess, shlex
# from distutils.dir_util import copy_tree
# DeprecationWarning: The distutils package is deprecated and slated for removal in Python 3.12. Use setuptools or check PEP 632 for potential alternatives
init()

PROJECT_GIT_DIR  = "D:\\Workspace\\Fallout 76 Quick Configuration\\Fallout76-QuickConfiguration\\"
PACK_TARGET_DIR  = "D:\\Workspace\\Fallout 76 Quick Configuration\\Files\\Main Files\\"

SEVENZIP_PATH    = "D:\\Portable\\7z\\7z.exe"
RCEDIT_PATH      = "D:\\Portable\\rcedit-x64.exe"
ISCC_PATH        = "C:\\Program Files (x86)\\Inno Setup 6\\ISCC.exe"
PANDOC_PATH      = "C:\\Program Files\\Pandoc\\pandoc.exe"

RELEASE_BIN_DIR  = os.path.join(PROJECT_GIT_DIR, "Fo76ini\\bin\\Release")
EXECUTABLE_NAME  = "Fo76ini.exe"
EXECUTABLE_PATH  = os.path.join(RELEASE_BIN_DIR, EXECUTABLE_NAME)
UPDATER_BIN_DIR  = os.path.join(PROJECT_GIT_DIR, "Fo76ini_Updater\\bin\\Release")
DEPENDENCIES_DIR = os.path.join(PROJECT_GIT_DIR, "Additional files")
VERSION_PATH     = os.path.join(PROJECT_GIT_DIR, "VERSION")
SETUP_ISS_PATH   = os.path.join(PROJECT_GIT_DIR, "setup.iss")

VERSION = "x.x.x"

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

def pack_release():
    print("Packing release...")
    target_dir = os.path.join(PACK_TARGET_DIR, "v" + VERSION)
    if os.path.exists(target_dir):
        print("Directory already exists, do you wish to proceed? (y/N)")
        if input(">>> ").strip().lower() != "y":
            print("Abort.")
            return
        else:
            print("Deleting files...")
            time.sleep(0.25)
            shutil.rmtree(target_dir)
    os.makedirs(target_dir, exist_ok=True)
    print("-----------------------------------------")
    print("Packing to v{0}_bin.zip...".format(VERSION))
    time.sleep(0.25)
    os.system("{0} a \"{1}\" \"{2}\\*\"".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_bin.zip"), RELEASE_BIN_DIR))
    print("-----------------------------------------")
    print("Packing to v{0}_src.zip...".format(VERSION))
    time.sleep(0.25)
    os.system("{0} a \"{1}\" \"{2}\\*\"".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip"), os.path.join(PROJECT_GIT_DIR, "Fo76ini")))
    print("-----------------------------------------")
    print("Cleaning v{0}_src.zip...".format(VERSION))
    time.sleep(0.25)
    os.system("{0} d \"{1}\" .vs".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    os.system("{0} d \"{1}\" bin".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    os.system("{0} d \"{1}\" obj".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    os.system("{0} d \"{1}\" packages".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    print("-----------------------------------------")
    print("Done.")

def extract_release():
    print("Extracting release...")
    target_dir = os.path.join(PACK_TARGET_DIR, "v" + VERSION)
    os.system("{0} x \"{1}\" -r -o\"{2}\" *".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_bin.zip"), os.path.join(target_dir, "v" + VERSION + "_bin")))

def use_rcedit():
    print("Setting executable version to '{0}'...".format(VERSION))
    os.system("{0} \"{1}\" --set-file-version {2} --set-product-version {2}".format(RCEDIT_PATH, EXECUTABLE_PATH, VERSION))
    print("Done.")

def copy_additions():
    print("Copying additional files...")
    copytree(DEPENDENCIES_DIR, RELEASE_BIN_DIR)
    print("Done.")

def copy_updater():
    print("Copying updater...")
    copytree(UPDATER_BIN_DIR, RELEASE_BIN_DIR)
    print("Done.")

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
            if line.startswith("#define ProjectPackTargetDir"):
                line = "#define ProjectPackTargetDir \"" + PACK_TARGET_DIR.rstrip("\\") + "\"\n"
                print("Line changed: " + line, end="")
            content += line
    with open(SETUP_ISS_PATH, "w") as f:
        f.write(content)

def build_inno():
    # os.system("setup.iss")
    print("Building setup using ISCC...")
    subprocess.run(shlex.split("\"" + ISCC_PATH + "\" \"" + SETUP_ISS_PATH + "\""))

def convert_md():
    print("Converting Markdown to HTML and RTF")
    subprocess.run(shlex.split("\"" + PANDOC_PATH + "\" --standalone --self-contained -f gfm \"What's new.md\" -o \"What's new.html\" --css=Pandoc/pandoc-style.css -H Pandoc/pandoc-header.html"))
    subprocess.run(shlex.split("\"" + PANDOC_PATH + "\" --standalone \"What's new.md\" -o \"What's new.rtf\""))

def open_dir():
    target_dir = os.path.join(PACK_TARGET_DIR, "v" + VERSION)
    if os.path.exists(target_dir):
        os.system("explorer.exe \"{0}\"".format(target_dir))
    else:
        os.system("explorer.exe \"{0}\"".format(PACK_TARGET_DIR))

# https://stackoverflow.com/a/7550424
def _mkdir(newdir):
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
            _mkdir(head)
        #print "_mkdir %s" % repr(newdir)
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
    # os.makedirs(dst)
    _mkdir(dst) # XXX
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

    warn_text = ""
    if not os.path.exists(PROJECT_GIT_DIR):
        warn_text += Fore.YELLOW + "WARN:  Project folder doesn't exist!\n"
    if not os.path.exists(PACK_TARGET_DIR):
        warn_text += Fore.YELLOW + "WARN:  Pack target folder doesn't exist!\n"
    if not os.path.exists(RCEDIT_PATH):
        warn_text += Fore.YELLOW + "WARN:  rcedit not found!\n"
    if not os.path.exists(SEVENZIP_PATH):
        warn_text += Fore.YELLOW + "WARN:  7-Zip not found!\n"
    if not os.path.exists(ISCC_PATH):
        warn_text += Fore.YELLOW + "WARN:  ISCC (Inno Setup) not found!\n"
    if not os.path.exists(PANDOC_PATH):
        warn_text += Fore.YELLOW + "WARN:  Pandoc not found!\n"

    if warn_text:
        print("-----------------------------------------\n" + warn_text + Fore.RESET, end="")

    get_version()

    while True:
        print("-----------------------------------------")
        time.sleep(0.25)
        print(f"""{Fore.BLUE}Set version
{Fore.MAGENTA}(1) {Fore.RESET} Set "VERSION" (current: {Fore.GREEN}{VERSION}{Fore.RESET})
{Fore.MAGENTA}(2) {Fore.RESET} Set executable version with rcedit

{Fore.BLUE}Prepare files
{Fore.MAGENTA}(3) {Fore.RESET} Copy additional files to release
{Fore.MAGENTA}(4) {Fore.RESET} Copy updater.exe to release

{Fore.BLUE}Pack release
{Fore.MAGENTA}(5) {Fore.RESET} Pack release
{Fore.MAGENTA}(6) {Fore.RESET} Extract *.zip
{Fore.MAGENTA}(7) {Fore.RESET} Update inno setup script
{Fore.MAGENTA}(8) {Fore.RESET} Build inno setup

{Fore.BLUE}What's new.md
{Fore.MAGENTA}(9) {Fore.RESET} Convert Markdown to HTML and RTF using Pandoc
{Fore.MAGENTA}(10){Fore.RESET} Push to GitHub repository

{Fore.BLUE}Others
{Fore.MAGENTA}(11){Fore.RESET} Open target folder
{Fore.MAGENTA}(0) {Fore.RESET} Exit
-----------------------------------------""")
        i = input(">>> ").strip()

        if i == "1":
            set_version()
        elif i == "2":
            use_rcedit()  
        elif i == "3":
            copy_additions()
        elif i == "4":
            copy_updater()
        elif i == "5":
            pack_release()
        elif i == "6":
            extract_release()
        elif i == "7":
            update_inno()
        elif i == "8":
            build_inno()
        elif i == "9":
            convert_md()
        elif i == "10":
            print("NOT IMPLEMENTED")
        elif i == "11":
            open_dir()
        elif i == "0" or i == "":
            print("""Bye bye!
-----------------------------------------""")
            time.sleep(0.25)
            break
