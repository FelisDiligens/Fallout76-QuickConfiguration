from colorama import Fore, Back, Style, init
import time, os, shutil
from distutils.dir_util import copy_tree
init()

PROJECT_GIT_DIR  = "C:\\Users\\Thomas\\Documents\\Fallout 76 Quick Configuration - Project files\\Fallout76-QuickConfiguration\\"
PACK_TARGET_DIR  = "C:\\Users\\Thomas\\Documents\\Fallout 76 Quick Configuration - Project files\\Files\\Main Files\\"

SEVENZIP_PATH    = "C:\\Portable\\7z\\7za.exe"
RCEDIT_PATH      = "C:\\Portable\\rcedit-x64.exe"

RELEASE_BIN_DIR  = os.path.join(PROJECT_GIT_DIR, "Fo76ini\\bin\\Release")
EXECUTABLE_PATH  = os.path.join(RELEASE_BIN_DIR, "Fo76ini.exe")
UPDATER_BIN_DIR  = os.path.join(PROJECT_GIT_DIR, "Fo76ini_Updater\\bin\\Release")
DEPENDENCIES_DIR = os.path.join(PROJECT_GIT_DIR, "Additional files")
VERSION_PATH     = os.path.join(PROJECT_GIT_DIR, "VERSION")

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
            time.sleep(1)
            shutil.rmtree(target_dir)
    os.makedirs(target_dir, exist_ok=True)
    print("-----------------------------------------")
    print("Packing to v{0}_bin.zip...".format(VERSION))
    time.sleep(1)
    os.system("{0} a \"{1}\" \"{2}\\*\"".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_bin.zip"), RELEASE_BIN_DIR))
    print("-----------------------------------------")
    print("Packing to v{0}_src.zip...".format(VERSION))
    time.sleep(1)
    os.system("{0} a \"{1}\" \"{2}\\*\"".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip"), os.path.join(PROJECT_GIT_DIR, "Fo76ini")))
    print("-----------------------------------------")
    print("Cleaning v{0}_src.zip...".format(VERSION))
    time.sleep(1)
    os.system("{0} d \"{1}\" .vs".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    os.system("{0} d \"{1}\" bin".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    os.system("{0} d \"{1}\" obj".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    os.system("{0} d \"{1}\" packages".format(SEVENZIP_PATH, os.path.join(target_dir, "v" + VERSION + "_src.zip")))
    print("-----------------------------------------")
    print("Done.")

def use_rcedit():
    print("Setting executable version to '{0}'...".format(VERSION))
    os.system("{0} \"{1}\" --set-file-version {2} --set-product-version {2}".format(RCEDIT_PATH, EXECUTABLE_PATH, VERSION))
    print("Done.")

def copy_additions():
    print("Copying additional files...")
    copy_tree(DEPENDENCIES_DIR, RELEASE_BIN_DIR, update=0)
    print("Done.")

def copy_updater():
    print("Copying updater...")
    copy_tree(UPDATER_BIN_DIR, RELEASE_BIN_DIR, update=0)
    print("Done.")

def update_inno():
    print("NOT IMPLEMENTED")
    pass

def build_inno():
    print("NOT IMPLEMENTED")
    pass

def open_dir():
    target_dir = os.path.join(PACK_TARGET_DIR, "v" + VERSION)
    if os.path.exists(target_dir):
        os.system("explorer.exe \"{0}\"".format(target_dir))
    else:
        os.system("explorer.exe \"{0}\"".format(PACK_TARGET_DIR))

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

    if warn_text:
        print("-----------------------------------------\n" + warn_text + Fore.RESET, end="")

    get_version()

    while True:
        print("-----------------------------------------")
        time.sleep(1)
        print(f"""{Fore.BLUE}Set version
{Fore.MAGENTA}(1){Fore.RESET} Set "VERSION" (current: {Fore.GREEN}{VERSION}{Fore.RESET})
{Fore.MAGENTA}(2){Fore.RESET} Set executable version with rcedit

{Fore.BLUE}Prepare files
{Fore.MAGENTA}(3){Fore.RESET} Copy additional files to release
{Fore.MAGENTA}(4){Fore.RESET} Copy updater.exe to release

{Fore.BLUE}Pack release
{Fore.MAGENTA}(5){Fore.RESET} Pack release
{Fore.MAGENTA}(6){Fore.RESET} Update inno setup script
{Fore.MAGENTA}(7){Fore.RESET} Build inno setup

{Fore.BLUE}Others
{Fore.MAGENTA}(8){Fore.RESET} Open target folder
{Fore.MAGENTA}(0){Fore.RESET} Exit
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
            update_inno()
        elif i == "7":
            build_inno()
        elif i == "8":
            open_dir()
        elif i == "0" or i == "":
            print("""Bye bye!
-----------------------------------------""")
            time.sleep(1)
            break