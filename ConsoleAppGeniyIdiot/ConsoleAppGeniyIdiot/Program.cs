using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GeniyIdiot.Common;

namespace ConsoleAppGeniyIdiot
{
    class Program
    {
        static int GetUserAnswer()
        {
            int userAnswerTrue = 0;
            string userAnswer = Console.ReadLine();
            while (!int.TryParse(userAnswer, out userAnswerTrue))
            {
                Console.WriteLine("Пожалуйста, введите число!");
                userAnswer = Console.ReadLine();
            }
            return userAnswerTrue;
        }

        public static int returnTest = 0;

        static void Main(string[] args)
        {
            while (returnTest == 0)
            {
                Console.WriteLine("Введите ФИО");
                var fullName = Console.ReadLine();
                var user = new User(fullName);
                var game = new Game(user);

                var questions = QuestionsStorage.GetQuestions();

                while (!game.IsEnd())
                {
                    Console.WriteLine(game.GetQuestionNumberInfo());
                    Console.WriteLine(game.GetRandomQuestions().Text);

                    var userAnswer = GetUserAnswer();

                    game.CountTheUserAnswer(userAnswer);
                }

                Console.WriteLine("Колличество правильных ответов: " + user.CountAnswer);

                var diagnose = game.CalculateDiagnose();
                Console.WriteLine(diagnose);

                game.SaveUserResult();

                Console.WriteLine("Добавить новый вопрос?");
                var userReply = Console.ReadLine();
                if (userReply == "Да")
                {
                    Console.WriteLine("Введите текст вопроса: ");
                    var userQuestion = Console.ReadLine();

                    Console.WriteLine("Введите текст ответа: ");
                    int userAnswerToNewQuestionTrue = 0;
                    string userAnswerToNewQuestion = Console.ReadLine();
                    while (!int.TryParse(userAnswerToNewQuestion, out userAnswerToNewQuestionTrue))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        userAnswerToNewQuestion = Console.ReadLine();
                    }


                    QuestionsStorage.Save(userQuestion, userAnswerToNewQuestion);
                }

                Console.WriteLine("Показать предыдущие результаты игры?");
                var userChoice = Console.ReadLine();
                if (userChoice == "Да")
                {
                    var listAnswer = game.GetUsersResults();
                    foreach (var ans in listAnswer)
                    {
                        Console.WriteLine($"{ans.Diagnose}\nПравильных ответов: {ans.CountAnswer}");
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("Хотите пройти тест заново?");
                var userChoiceReturnTest = Console.ReadLine();
                if (userChoiceReturnTest == "Нет")
                {
                    returnTest++;
                }
            }
        }
    }
}
    

