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
        public MongoClient Client { get; set; }
        public IMongoDatabase Db { get; set; }

        public MongoDBRepo(string url, string database)
        {
            Client = new MongoClient(url);
            Db = Client.GetDatabase(database);

        }
    }

}