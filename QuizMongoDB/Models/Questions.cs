using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMongoDB.Models
{
    public class Questions
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswers { get; set; }
        public string Category { get; set; }
    }
}
