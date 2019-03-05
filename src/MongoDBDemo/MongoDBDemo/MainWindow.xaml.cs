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
        private IMongoCollection<BsonDocument> MyConnection;

        public MainWindow()
        {
            InitializeComponent();
            MyConnection = GetConnection();
        }

        public IMongoCollection<BsonDocument> GetConnection()
        {
            // or use a connection string
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("col");
            return collection;
        }

        public string Query()
        {
            var documents = MyConnection.Find(new BsonDocument()).ToList();
            var sb = new StringBuilder();
            foreach (var doc in documents)
            {
                sb.Append(doc.ToJson().ToString());
            }
            return sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txb.Text = Query();
        }
    }
}
