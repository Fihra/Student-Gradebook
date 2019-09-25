using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDirectory.Models
{
    public class Student
    {
        [BsonId]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public int Age { get; set; }
    }
}