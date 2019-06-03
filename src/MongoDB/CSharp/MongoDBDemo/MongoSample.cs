using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBDemo.Models;

namespace MongoDBDemo
{
    public class MongoSample
    {
        private readonly IMongoClient client;
        private readonly IMongoCollection<BsonDocument> collection;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<col> collectionCol;

        public MongoSample()
        {
            var connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase("test");
            collection = database.GetCollection<BsonDocument>("sample");
            collectionCol = database.GetCollection<col>("col");
        }

        public void Ex1()
        {
            var documents = new BsonDocument[]
            {
                new BsonDocument
                {
                    { "name", "item1" },
                    { "value", 25 },
                    { "isDeleted", false},
                    { "tags", new BsonArray { "blank", "green" } },
                    { "items", new BsonArray{
                        new BsonDocument { { "name", Guid.NewGuid().ToString() }, { "isDeleted", true }, { "value", 4 } }
                        , new BsonDocument { { "name", Guid.NewGuid().ToString() }, { "isDeleted", false }, { "value", 5 } } } }
                },
                new BsonDocument
                {
                    { "name", "item2" },
                    { "value", 15 },
                    { "isDeleted", false},
                    { "tags", new BsonArray { "blank", "red" } },
                    { "items", new BsonArray{
                        new BsonDocument { { "name", Guid.NewGuid().ToString() }, { "isDeleted", true }, { "value", 7 } }
                        , new BsonDocument { { "name", Guid.NewGuid().ToString() }, { "isDeleted", false }, { "value", 10 } } } }
                },
                new BsonDocument
                {
                    { "name", "item3" },
                    { "value", 22 },
                    { "isDeleted", false},
                    { "tags", new BsonArray { "blank", "yellow" } },
                    { "items", new BsonArray{
                        new BsonDocument { { "name", Guid.NewGuid().ToString() }, { "isDeleted", true }, { "value", 9 } }
                        , new BsonDocument { { "name", Guid.NewGuid().ToString() }, { "isDeleted", true }, { "value", 5 } } } }
                },
            };

            collection.InsertMany(documents);

        }

        public void Ex2()
        {
            var count = collection.CountDocuments(new BsonDocument());
            var document = collection.Find(new BsonDocument()).FirstOrDefault();
            var allDoc = collection.Find(new BsonDocument()).ToList();
            var filter = Builders<BsonDocument>.Filter.Eq("name", "item1");
            var filterDoc = collection.Find(filter);
        }

        //Get a Set of Documents with a Filter
        public void Ex3()
        {
            //value > 21
            var filter = Builders<BsonDocument>.Filter.Gt("value", 21);

            //20 < value < 25
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter2 = filterBuilder.Gt("value", 20) & filterBuilder.Lte("value", 25);
        }

        public void Ex4()
        {
            //var list = collectionCol.AsQueryable()
            //    .GroupBy(x => x.title)
            //    .Select(g => new { title = g.Key, count = g.Count() })
            //    .ToList();

            var groups = collectionCol.AsQueryable()
                .GroupBy(x => x.title)
                .ToList();

            foreach (var group in groups.OrderBy(x=>x.Key))
            {
                //此数据位空，不知道是不是MongodbDriver的Bug
                foreach (var col in group)
                {
                    
                }
            }
        }

    }
}
