using MongoDB.Driver;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using MongoDBDemo.Models;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDBDemo
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
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MyConnection = GetConnection();
            var databases = ListDatabase();
            foreach(var db in databases)
            {
                txb.AppendText(db.ToString()+'\n');
            }
        }

        private IMongoCollection<col> MyConnection;
        //建议将MongoClient实例存储在全局位置，
        //要么作为静态变量，要么存储在具有单例生命周期的IoC容器中。
        //---MongoDB官方文档
        public static MongoClient Client { private set; get; }
        private MongoDBHelper helper = new MongoDBHelper("mongodb://localhost:27017", "test");

        public IMongoCollection<col> GetConnection()
        {
            //var client = new MongoClient("mongodb://host:27017,host2:27017/?replicaSet=rs0");
            Client = new MongoClient("mongodb://localhost:27017");
            var database = Client.GetDatabase("test");
            var collection = database.GetCollection<col>("col");
            return collection;
        }
        public List<BsonDocument> ListDatabase()
        {
            using(var cursor = Client.ListDatabases())
            {
                var list = cursor.ToList();
                return list;
            }
        }
        public List<col> SelectAll()
        {
            ////Filter方式
            //var list = MyConnection.Find("{}").ToList();
            //return list;

            //Lambda方式
            var list = MyConnection.AsQueryable().ToList();
            return list;
        }

        public List<col> Select()
        {
            ////Filter方式1
            //var filter = Builders<col>.Filter.Eq("by", "菜鸟教程");
            ////Filter方式2
            var filter = Builders<col>.Filter.Eq(x => x.by, "菜鸟教程");
            //var list = MyConnection.Find(filter).ToList();
            //return list;

            //LinQ方式
            //var query = from e in MyConnection.AsQueryable()
            //            where e.@by == "菜鸟教程"
            //            select e;
            //return query.ToList();

            //Lambda表达式
            var query = MyConnection.AsQueryable().Where(x => x.by == "菜鸟教程").ToList();
            return query;
        }
        // SelectMany、Skip、Take内嵌数组排序分页
        public List<col> SelectPage()
        {
            // 页码
            var index = 4;
            // 页面大小
            var size = 10;

            var page = MyConnection.AsQueryable()
                .Where(s => s.description == "更新了描述信息")
                .OrderBy(r => r.lastModified)
                .Skip((index - 1) * size)
                .Take(size);

            //var page1 = IAsyncCursorSourceExtensions.ToList(page);

            return page.ToList();
        }
        public void Insert()
        {
            var list = new List<col>();
            var col = new col()
            {
                title = "测试" + Guid.NewGuid().ToString().Replace("-", ""),
                description = "这是描述信息",
                by = "by",
                url = "www.github.com",
                likes = 10
            };
            list.Add(col);
            MyConnection.InsertOne(col);
            //MyConnection.InsertMany(list);
        }

        public long Delete()
        {
            var filter = Builders<col>.Filter.Eq("by", "by");

            var result = MyConnection.DeleteOne(filter);
            return result.DeletedCount;
            //MyConnection.DeleteMany(filter);
        }

        public long Update()
        {
            var filter = Builders<col>.Filter.Eq("by", "by");
            var list = new List<col>();
            var update = Builders<col>.Update.Set("by", "更新了by").Set("description", "更新了描述信息").CurrentDate("lastModified");
            var result = MyConnection.UpdateOne(filter, update);
            return result.ModifiedCount;
            //MyConnection.UpdateMany(filter, update);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectAll();
        }
    }
}
