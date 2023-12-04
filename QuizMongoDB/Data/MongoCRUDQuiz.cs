using MongoDB.Driver;
using QuizMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace QuizMongoDB.Data
{
    internal class MongoCRUDQuiz
    {
        private IMongoDatabase db;
        public MongoCRUDQuiz(string database) 
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
            //FIllDatabase();
        }

        public void FIllDatabase()
        {
            List<Questions> questions = new List<Questions>();

            Questions question6 = new Questions()
            {
                Statement = "Vem är den nuvarande NBA kommissionären?",
                Answers = new string[] { "Adam Silver", "David Stern", "Roger Goodell", "Rob Manfred" },
                CorrectAnswers = 0,
                Category = "Sport"
            };
            questions.Add(question6);

            Questions questions7 = new Questions()
            {
                Statement = "Vad kallas det när en spelare gör poäng och blir foulad?",
                Answers = new string[] { "Slam Dunk", "And-One", "Fast Break", "Three Pointer"},
                CorrectAnswers = 1,
                Category = "Sport"
            };
            questions.Add(questions7);

            var collection = db.GetCollection<Questions>("Questions");
            collection.InsertMany(questions);
        }

        public List<Questions> ReadAllQuestions(string table)
        {
            var collection = db.GetCollection<Questions>(table);
            return collection.Find(_ => true).ToList();
        }

        public void UpdateQuestion(string table, Questions question)
        {
            var collection = db.GetCollection<Questions>(table);
            question.Statement = "Vem är den nuvarande NBA kommissionären?";
            question.Answers = new string[] { "Adam Silver", "David Stern", "Roger Goodell", "Rob Manfred" };
            question.CorrectAnswers = 0;
            question.Category = "Sport";
            collection.ReplaceOne(x => x.Id == question.Id, question, new ReplaceOptions { IsUpsert = true }); 
        }

        public void DeleteQuestion(string table, Questions question)
        {
            var collection = db.GetCollection<Questions>(table);
            collection.DeleteOne(x => x.Id == question.Id);
        }
    }
}
