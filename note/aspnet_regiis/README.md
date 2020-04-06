## aspnet_regiis

我们在写C#应用程序时，在工程文件中放置一个app.config，程序打包时，系统会将该配置文件自动编译为与程序集同名的.exe.config 文件。作用就是应用程序安装后，只需在安装目录中找到该文件，需改字符串内容，就可以改变运行参数，而不用修改源程序代码。例如：可以使用配置文件保存数据库连接字符串；在应用程序中显示变动的文字信息等等。

1. 文件位置：C:\Windows\Microsoft.NET\Framework\v4.0.30319\
2. 在该位置打开PowerShell，运行以下命令

```powershell
./aspnet_regiis.exe -pef "connectionStrings" "E:\开发目录"
```

