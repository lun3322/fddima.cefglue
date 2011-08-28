@echo off

set PythonExePath=c:\python27\python.exe
if exist "%PythonExePath%" goto run
set PythonExePath=c:\python26\python.exe
if exist "%PythonExePath%" goto run
set PythonExePath=python.exe

:run
"%PythonExePath%" translator.py --no-backup --cpp-header ../include/cef.h --cefglue ../../CefGlue/Core/libcef.cs --cefglue-dir ./cefglue
pause
