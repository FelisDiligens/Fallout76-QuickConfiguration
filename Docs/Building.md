# Build process

## Requirements
- Windows 10 or later
- [Visual Studio 2022 Community edition](https://visualstudio.microsoft.com/vs/community/)
    - [".NET Desktop Development" workload installed](https://learn.microsoft.com/en-us/visualstudio/install/modify-visual-studio?view=vs-2022)

### Optional
- [git](https://git-scm.com/) (optional, needed if you want to clone the repo or contribute)
- [Python 3](https://www.python.org/downloads/) (optional, needed if you want to use the build script)
- [Inno Setup](https://jrsoftware.org/isdl.php) (optional, needed to build the installer)
- [pandoc](https://pandoc.org/installing.html) (optional, needed if you want to make html/rtf versions of the "What's new.md" file)

## Building the application
1. Open the solution `Fallout76-QuickConfiguration\Fo76ini\Fo76ini.sln` in Visual Studio 2022.
2. Set the build target to "Release", "Any CPU", and "Fo76ini_Updater"
3. Click Build → Build Solution (F6)
4. Copy (and replace) the content of `Fallout76-QuickConfiguration\Fo76ini_Updater\bin\Release\` into  `Fallout76-QuickConfiguration\Fo76ini\bin\Release\`. (Create the latter directory, if it does not exist)
5. Next, set the build target to "Release", "Any CPU", and "Fo76ini"
6. Once again, click Build → Build Solution (F6)
7. Copy the content of `Fallout76-QuickConfiguration\Additional files\` into `Fallout76-QuickConfiguration\Fo76ini\bin\Release\`
8. Done.

## Building the setup
1. Open `Fallout76-QuickConfiguration\setup.iss` in Inno Setup Compiler.
2. Edit the first few lines, such as `ProjectVersion`, `ProjectGitDir`, `ProjectPackTargetDir`
3. You'll probably also need to edit these lines:
    ```
    [Files]
    Source: "{#ProjectPackTargetDir}\v{#ProjectVersion}\v{#ProjectVersion}_bin\Fo76ini.exe"; DestDir: "{app}"; Flags: ignoreversion
    Source: "{#ProjectPackTargetDir}\v{#ProjectVersion}\v{#ProjectVersion}_bin\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
    ; NOTE: Don't use "Flags: ignoreversion" on any shared system files
    ```
    to something like this:
    ```
    [Files]
    Source: "{#ProjectGitDir}\Fo76ini\bin\Release\Fo76ini.exe"; DestDir: "{app}"; Flags: ignoreversion
    Source: "{#ProjectGitDir}\Fo76ini\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
    ; NOTE: Don't use "Flags: ignoreversion" on any shared system files
    ```
4. Build the setup.