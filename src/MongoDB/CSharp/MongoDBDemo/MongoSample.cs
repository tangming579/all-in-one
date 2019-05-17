using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBDemo
{
    public class MongoSample
    {
        private readonly IMongoClient client;
        private readonly IMongoCollection<BsonDocument> collection;
        private readonly IMongoDatabase database;

        public MongoSample()
        {
            var connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase("test");
            collection = database.GetCollection<BsonDocument>("sample");
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
    }
}
