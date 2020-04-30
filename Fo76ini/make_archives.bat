@ECHO off
IF "%~1"=="" GOTO errarg
ECHO Creating archives...

ECHO Creating binary zip
cd bin\Release
7z a "..\..\..\..\Files\Main Files\%1\%1_bin.zip" .\*
cd ..\..

ECHO Creating source code zip
7z a "..\..\Files\Main Files\%1\%1_src.zip" .\*
7z d "..\..\Files\Main Files\%1\%1_src.zip" .vs
7z d "..\..\Files\Main Files\%1\%1_src.zip" bin
7z d "..\..\Files\Main Files\%1\%1_src.zip" obj
7z d "..\..\Files\Main Files\%1\%1_src.zip" packages

GOTO end
:errarg
ECHO Please pass a version number as argument.
:end