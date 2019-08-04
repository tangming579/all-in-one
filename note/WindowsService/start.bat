@echo.请稍等，服务启动......  
@echo off  
@sc create GX binPath= "C:\Users\tangming\source\repos\WindowsService1\bin\Debug\WindowsService1.exe"
@sc start GX
@sc config GX start= AUTO  
@sc description GX 定时写文件服务
@echo off  
@echo.启动完毕！  
@pause