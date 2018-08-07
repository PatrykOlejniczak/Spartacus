@echo off

SETLOCAL EnableDelayedExpansion

IF NOT EXIST %~dp0..\Spartacus\bin\Release\netcoreapp2.1\Spartacus.dll (
    call %~dp0\build.cmd
)

FOR /l %%I IN (1,1 3) DO (
    dotnet %~dp0..\Spartacus\bin\Release\netcoreapp2.1\Spartacus.dll simplex --dimension 2 -p 25000 --outputpath %~dp0 --output simplex_%%I --elements %%I
)

ENDLOCAL
