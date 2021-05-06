using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeniyIdiot.Common
{
    public class QuestionsStorage
    {
        public static string path = "questionStorage.txt";

        public static void Save(string newQuestion, string newAnswer)
        {
            var information = newQuestion + "#" + newAnswer;
            FileProvide.Save(path, information);
        }

        public static List<Questions> GetQuestions()
        {
            var questions = new List<Questions>();
            questions.Add(new Questions("Сколько будет два плюс два  умноженное на два?", 6));
            questions.Add(new Questions("Бревно нужно распилить на 10  частей, сколько надо сделать  распилов?", 9));
            questions.Add(new Questions("На двух руках 10 пальцев.Сколько пальцев на 5 руках ?", 25));
            questions.Add(new Questions("Укол делают каждые полчаса, сколько нужно минут для трех  уколов ?", 60));
            questions.Add(new Questions("Пять свечей горело, две  потухли. Сколько свечей  осталось?", 2));

            if (File.Exists(path))
            {
                var information = FileProvide.Get(path);
                var lines = information.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var data = line.Split('#');
                    questions.Add(new Questions(data[0], Convert.ToInt32(data[1])));
                }
            }
            return questions;
        }
    }
}
