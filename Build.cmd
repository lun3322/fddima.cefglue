@echo off & setlocal enableextensions enabledelayedexpansion

call "SetEnv.cmd"
if "%errorlevel%" neq "0" goto errSetEnv

:: default arguments
:main
set Configuration=Release
set Target=Build
set Platform=x86

:: build
MSBuild.exe /nologo /v:m /tv:4.0 /m /nr:false "CefGlue.sln" /p:Configuration="%Configuration%";Platform="%Platform%" /t:"%Target%"
if "%errorlevel%" neq "0" goto errBuild
goto :eof

:: errors
:errBuild
echo.Error: Build error.
exit /b 1

:errSetEnv
echo.Error: SetEnv error.
exit /b 1
