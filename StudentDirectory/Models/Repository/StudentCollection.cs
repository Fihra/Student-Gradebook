using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;

namespace StudentDirectory.Models.Repository
{
    public class StudentCollection
    {
        internal MongoDBRepo _repo = new MongoDBRepo("mongodb://127.0.0.1:27017", "StudentDB");
        private const string _collection = "StudentCollection";
        public IMongoCollection<Student> Collection;

        public StudentCollection()
        {
            Collection = _repo.Db.GetCollection<Student>(_collection);
        }

        public void InsertStudent(Student student)
        {
            Collection.InsertOne(student);
        }

        public List<Student> SelectAll()
        {
            var query = Collection.Find(new BsonDocument()).ToList();
            return query;
        }

        public Student Get(string id)
        {
            return Collection.Find(new BsonDocument { { "_id", new Guid(id) } }).First();
        }

        public void UpdateStudent(string id, Student student)
        {
            student.Id = new Guid(id);
            var filter = Builders<Student>.Filter.Eq(s => s.Id, student.Id);
            Collection.ReplaceOne(filter, student);
        }
    }
}