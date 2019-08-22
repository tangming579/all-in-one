using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

namespace Log4netSqliteDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(new Action(() =>
            {
                var list = LoggerHelper.GetLoggers();
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txbLogs.Text = JArray.FromObject(list) + "";
                }));

            }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoggerHelper.Logger.Info("测试");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MainData.json");
                var str = System.IO.File.ReadAllText(path);
                var json = JObject.Parse(str);
            }
            catch (Exception exp)
            {
                LoggerHelper.Logger.Error("json parse failed", exp);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Task.Run(new Action(() =>
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MainData.json");
                var str = System.IO.File.ReadAllText(path);
                var json = JObject.Parse(str);
            }));
        }
    }
}
