using QuizMongoDB.Models;
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
using System.Windows.Shapes;

namespace QuizMongoDB
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView : Window
    {
        private int currentIndex = 0;
        public string QuestionCount { get; set; }
        public Questions currentStatement { get; set; }
        public List<Questions> Questions  { get; set; }
        private int score = 0;
        private int TotalScore = 0;
        public QuizView(List<Questions> questions) 
        {
            InitializeComponent();
            Questions = questions;
            ShowNextStatement();
        }

        public void ShowNextStatement()
        {
            if (currentIndex < Questions.Count)
            {
                currentStatement = Questions[currentIndex];
                CurrentStatementText.Text = currentStatement.Statement;
                AnswerA.Content = currentStatement.Answers[0];
                AnswerB.Content = currentStatement.Answers[1];
                AnswerC.Content = currentStatement.Answers[2];
                AnswerD.Content = currentStatement.Answers[3];
                QuestionCount = $"Question {currentIndex + 1} of {Questions.Count}";
            } else
            {
                MessageBox.Show($"Du fick {TotalScore} poäng");
            }
            QuestionCountText.Text = QuestionCount;
            ScoreText.Text = $"Score: {score}";
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse((sender as Button).Tag.ToString()) == currentStatement.CorrectAnswers)
            {
                currentIndex++;
                score++;
                TotalScore++;
                ShowNextStatement();
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }
    }
}
