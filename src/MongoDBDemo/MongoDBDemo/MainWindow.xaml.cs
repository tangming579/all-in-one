using MongoDB.Bson;
using MongoDB.Driver;
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

namespace MongoDBDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMongoCollection<col> MyConnection;
        private MongoDBHelper helper = new MongoDBHelper();

        public MainWindow()
        {
            InitializeComponent();
            MyConnection = GetConnection();
            //helper.Get()
        }

        public IMongoCollection<col> GetConnection()
        {
            // or use a connection string
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<col>("col");
            return collection;
        }

        public string Query()
        {
            var documents = MyConnection.AsQueryable().ToList();
            var sb = new StringBuilder();
            foreach (var doc in documents)
            {
                sb.Append(doc.ToString());
            }
            return sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txb.Text = Query();
        }

        public class col
        {
            public ObjectId id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string by { get; set; }
            public string url { get; set; }
            public string[] tags { get; set; }
            public int likes { get; set; }

            public override string ToString()
            {
                return $"'title:{title} description:{description} url:{url}"+'\n';
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            var col = new col()
            {
                title = "测试" + Guid.NewGuid().ToString().Replace("-", ""),
                description = "这是描述信息",
                by = "by",
                url = "www.github.com",
                likes = 10
            };

            MyConnection.InsertOne(col);
        }
    }
}
