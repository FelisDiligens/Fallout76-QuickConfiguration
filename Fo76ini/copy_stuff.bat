@ECHO off
XCOPY 7z bin\Debug\7z /I /C /E /Y
XCOPY docs bin\Debug\docs /I /C /E /Y
XCOPY languages bin\Debug\languages /I /C /E /Y
XCOPY 7z bin\Release\7z /I /C /E /Y
XCOPY docs bin\Release\docs /I /C /E /Y
XCOPY languages bin\Release\languages /I /C /E /Y