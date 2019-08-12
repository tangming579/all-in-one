cd /d %~dp0 

SC QUERY Service1 > NUL
IF ERRORLEVEL 1060 GOTO NOTEXIST
GOTO EXIST

:NOTEXIST
InstallUtil.exe Service1.exe
@sc config Service1 start= AUTO  
Net Start Service1
GOTO END

:EXIST
Net Stop Service1
InstallUtil.exe /u Service1.exe
GOTO NOTEXIST

:END
pause