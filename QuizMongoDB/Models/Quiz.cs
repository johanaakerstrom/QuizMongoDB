using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMongoDB.Models
{
    public class Quiz
    {
        public List<Questions> Questions { get; set; }
        public string Title { get; set; }
    }
}
