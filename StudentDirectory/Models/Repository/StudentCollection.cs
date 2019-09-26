﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;

namespace StudentDirectory.Models.Repository
{
    public class StudentCollection
    {
        //internal MongoDBRepo _repo = new MongoDBRepo("mongodb://127.0.0.1:27017", "StudentDB");
        //private const string _collection = "StudentCollection";
        public IMongoCollection<Student> Collection;

        public StudentCollection()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("StudentsDB");
            Collection = db.GetCollection<Student>("Students");
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
            return Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).First();
        }

        public void UpdateStudent(string id, Student student)
        {
            student.Id = new ObjectId(id);
            var filter = Builders<Student>.Filter.Eq(s => s.Id, student.Id);
            Collection.ReplaceOne(filter, student);
        }

        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Movie movie = db.Movies.Find(id);
        //    db.Movies.Remove(movie);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public void DeleteStudent(string id, Student student)
        {
            student.Id = new ObjectId(id);
            
            Collection.DeleteOne(s => s.Id == student.Id);
        }
    }
}