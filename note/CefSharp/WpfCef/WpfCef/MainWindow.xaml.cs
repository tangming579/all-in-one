using CefSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCef
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            //browser.JavascriptObjectRepository.ResolveObject += JavascriptObjectRepository_ResolveObject;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //browser.ShowDevTools();
            this.browser.Address = AppDomain.CurrentDomain.BaseDirectory + @"index.html";

            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            browser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(), true, BindingOptions.DefaultBinder);
            //js是否已成功绑定
            browser.JavascriptObjectRepository.ObjectBoundInJavascript += (sender1, e1) =>
            {
                var name = e1.ObjectName;

                Debug.WriteLine($"Object {e1.ObjectName} was bound successfully.");
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = new Model();
            obj.name = "hello";
            obj.age = 2;
            var jsons = new JavaScriptSerializer().Serialize(obj);
            string js = $"test1({jsons});";
            browser.ExecuteScriptAsync(js);
        }

        private async void Button_Click1(object sender, RoutedEventArgs e)
        {
            var obj = new JObject();
            obj["name"] = "hello";
            obj["age"] = 12;
            string js = $"test2({obj});";
            var response = await browser.EvaluateScriptAsync(js);
            MessageBox.Show(response.Result + "");
        }

        public class Model
        {
            public string name { get; set; }
            public int age { get; set; }
        }

        public class BoundObject
        {
            //方法只能以小写字母开头
            public int add(int a, int b)
            {
                return a + b;
            }
            public void showMessage(string msg)
            {
                MessageBox.Show(msg);
            }
        }
    }
}
