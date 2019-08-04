using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDemo.Models
{
    public class col
    {
        public ObjectId id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string by { get; set; }
        public string url { get; set; }
        public string[] tags { get; set; }
        public int likes { get; set; }
        public DateTime? lastModified { get; set; }

        public override string ToString()
        {
            return $"'title:{title} description:{description} url:{url}" + '\n';
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
