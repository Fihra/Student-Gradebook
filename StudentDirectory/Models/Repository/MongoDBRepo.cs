using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace StudentDirectory.Models.Repository
{
    public class MongoDBRepo
    {
        public IMongoDatabase db;

        public MongoDBRepo(string url, string database)
        {
            var client = new MongoClient(url);
            db = client.GetDatabase(database);
        }
    }

}