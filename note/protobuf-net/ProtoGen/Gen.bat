@echo off

echo bat path : %~dp0

for  /f  %%a  in  ('"dir  %~dp0\protos\*.proto /B"')  do (
	echo %%a
	cd /d %~dp0\protos
	..\protogen.exe -i:%%a -o:..\output\%%a.cs -ns:Nuctech.NIS.Common.Protocol
)

pause