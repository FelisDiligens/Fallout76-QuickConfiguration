@ECHO off
IF "%~1"=="" GOTO errarg
ECHO .............................................................................................................
ECHO                                                  Preparation
ECHO .............................................................................................................
ECHO Deleting previous files.
del /s /f /q "..\..\Files\Main Files\v%1\*.*"
ECHO.
ECHO Setting version information with rcedit.
cd bin\Release
rcedit Fo76ini.exe --set-file-version %1 --set-product-version %1
ECHO.

ECHO .............................................................................................................
ECHO                                              Creating binary zip
ECHO .............................................................................................................
7z a "..\..\..\..\Files\Main Files\v%1\v%1_bin.zip" .\*
7z d "..\..\..\..\Files\Main Files\v%1\v%1_bin.zip" *.log.txt
ECHO.

ECHO .............................................................................................................
ECHO                                             Extracting binary zip
ECHO .............................................................................................................
7z x "..\..\..\..\Files\Main Files\v%1\v%1_bin.zip" -r -o"..\..\..\..\Files\Main Files\v%1\v%1_bin" *
ECHO.

ECHO .............................................................................................................
ECHO                                            Creating source code zip
ECHO .............................................................................................................
cd ..\..
7z a "..\..\Files\Main Files\v%1\v%1_src.zip" .\*
7z d "..\..\Files\Main Files\v%1\v%1_src.zip" .vs
7z d "..\..\Files\Main Files\v%1\v%1_src.zip" bin
7z d "..\..\Files\Main Files\v%1\v%1_src.zip" obj
7z d "..\..\Files\Main Files\v%1\v%1_src.zip" packages
ECHO.

ECHO .............................................................................................................
ECHO                                                  Finishing up
ECHO .............................................................................................................
ECHO Write %1 to VERSION file
ECHO %1 > ..\VERSION
ECHO Done.

GOTO end
:errarg
ECHO Please pass a version number as argument.
:end