using QuizMongoDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Driver;
using QuizMongoDB.Models;

namespace QuizMongoDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MongoCRUDQuiz mongo;
        public static List<Questions> questions = new List<Questions>();
        public MainWindow()
        {
            InitializeComponent();
            mongo = new MongoCRUDQuiz("QuizDB");
            ReadAllQuestionWithBson();
            //UpdateOneQuestion();
            //DeleteOneQuestion();
        }

        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            QuizView StartQuiz = new QuizView(questions);
            StartQuiz.Show();
            this.Close();
        }

        public void ReadAllQuestionWithBson()
        {
            questions = mongo.ReadAllQuestions("Questions");           
        }

        public void UpdateOneQuestion()
        {
            mongo.UpdateQuestion("Questions", questions[4]);
        }

        public void DeleteOneQuestion()
        {
            mongo.DeleteQuestion("Questions", questions[4]);
        }
        
    }
}
