using CefSharp;
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

            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            this.browser.Address = AppDomain.CurrentDomain.BaseDirectory + @"index.html";
            //browser.JavascriptObjectRepository.ResolveObject += JavascriptObjectRepository_ResolveObject;
        }

        private void JavascriptObjectRepository_ResolveObject(object sender, CefSharp.Event.JavascriptBindingEventArgs e)
        {
            var repo = e.ObjectRepository;
            if (e.ObjectName == "bound")
            {
                repo.Register("bound", new JsEvent(), isAsync: true,
                    options: new BindingOptions()
                    {
                        
                    });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var jsons = "hello";
            var js= $"test1({jsons});";
            browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(js);
        }

        private async void Button_Click1(object sender, RoutedEventArgs e)
        {
            string script = "";
            var response = await browser.EvaluateScriptAsync(script);
            MessageBox.Show(response.Result + "");
        }
    }
}
