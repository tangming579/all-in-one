@echo.���Եȣ���������......  
@echo off  
@sc create GX binPath= "C:\Users\tangming\source\repos\WindowsService1\bin\Debug\WindowsService1.exe"
@sc start GX
@sc config GX start= AUTO  
@sc description GX ��ʱд�ļ�����
@echo off  
@echo.������ϣ�  
@pause