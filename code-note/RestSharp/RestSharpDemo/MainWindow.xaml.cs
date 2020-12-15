using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Newtonsoft.Json.Linq;
using RestSharp;

namespace RestSharpDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        RestClient client = new RestClient();

        public MainWindow()
        {
            InitializeComponent();

            client.BaseUrl = new Uri("http://192.168.100.1:82");
            client.Timeout = 3600;

            //Login();

            //GetServerState();
            UpdateMyPassword();
        }

        public async Task Login()
        {
            var password = Encrypt("78543600");
            var request = new RestRequest(Method.GET);
            request.Resource = "/api/Authorize/GetAuthorize/";
            request.AddParameter("loginMode", 1);
            request.AddParameter("tbuserid", "sa");
            request.AddParameter("tbpassword", password);
            request.AddParameter("clientType", 1);
            IRestResponse response = await client.ExecuteAsync<LoginResult>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JObject.Parse(response.Content);
            }
        }

        public async Task GetServerState()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/api/Login/GetServerState";
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JObject.Parse(response.Content);
            }
        }

        public async Task UpdateMyPassword()
        {
            var passwordOld = Encrypt("78543600");
            var passwordNew = Encrypt("78543600");

            var content = new JObject();
            content["userid"] = "sa";
            content["pwd"] = new JArray { passwordOld, passwordNew };

            var request = new RestRequest(Method.POST);
            request.Resource = "/api/MyInfo/UpdateMyPassword";
            request.AddParameter("application/json", content, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JObject.Parse(response.Content);
            }
        }

        public class LoginResult
        {
            public bool success { get; set; }
            public string msg { get; set; }
            public int code { get; set; }
           
        }

        public string Encrypt(string strInput)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(strInput);//以字节方式存储
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] result = sha1.ComputeHash(data);//得到哈希值
            return Convert.ToBase64String(result); //转换成为字符串的显示
        }
    }
}
