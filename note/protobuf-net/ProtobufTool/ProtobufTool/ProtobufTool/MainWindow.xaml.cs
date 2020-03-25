using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProtobufTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            txbOutput.Clear();
            switch (cobVersion.SelectedIndex)
            {
                case 0: txbOutput.Text = protogen(); break;
                case 1: txbOutput.Text = protoc(); break;
            }
        }

        //生成proto3
        public string protoc()
        {
            string command = $@".\protoc.exe --proto_path=gen --csharp_out=gen test.proto";

            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";

            pro.StartInfo.CreateNoWindow = true;         // 不创建新窗口    
            pro.StartInfo.UseShellExecute = false;       //不启用shell启动进程  
            pro.StartInfo.RedirectStandardInput = true;  // 重定向输入    
            pro.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
            pro.StartInfo.RedirectStandardError = true;
            // 重定向错误输出  
            pro.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            pro.Start();//开启cmd
            pro.StandardInput.WriteLine(command);
            pro.StandardInput.AutoFlush = true;
            pro.StandardInput.WriteLine("exit"); //若是运行时间短可加入此命令

            string output = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();//若运行时间长,使用这个,等待程序执行完退出进程
            pro.Close();
            return output;
        }

        //老版protogen生成器，只可生成proto2
        public string protogen()
        {
            string outputPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            //string command = $@"ProtoGen\protogen.exe -i:protos\Proto2.proto -o:output\Proto2.cs";
            string command = $@"ProtoGen\protogen.exe -i:output\MQMessage.cs -o:protos\Proto2.proto";

            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";

            pro.StartInfo.CreateNoWindow = true;         // 不创建新窗口    
            pro.StartInfo.UseShellExecute = false;       //不启用shell启动进程  
            pro.StartInfo.RedirectStandardInput = true;  // 重定向输入    
            pro.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
            pro.StartInfo.RedirectStandardError = true;
            // 重定向错误输出  
            pro.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            pro.Start();//开启cmd
            pro.StandardInput.WriteLine(command);
            pro.StandardInput.AutoFlush = true;
            //pro.StandardInput.WriteLine("exit"); //若是运行时间短可加入此命令

            string output = pro.StandardOutput.ReadToEnd();
            //pro.StandardInput.WriteLine("exit");
            pro.WaitForExit();//若运行时间长,使用这个,等待程序执行完退出进程
            pro.Close();
            return output;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileType = cobType.SelectedIndex == 0 ? "proto" : "cs";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.Filter = $"{fileType}文件|*.{fileType}|所有文件|*.*";
            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            //openFileDialog.DefaultExt = "cs";
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                txbOriginal.Text = openFileDialog.FileName;
            }            
        }
    }
}
