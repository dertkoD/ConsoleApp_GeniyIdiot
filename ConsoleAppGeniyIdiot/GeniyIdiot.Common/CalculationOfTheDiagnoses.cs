namespace GeniyIdiot.Common
{
    class CalculationOfTheDiagnoses
    {
        public static string Calculate(int countQuestions, User user)
        {
            var diagnosis = new string[countQuestions + 1];
            diagnosis[0] = "Идиот";
            diagnosis[1] = "Кретин";
            diagnosis[2] = "Дурак";
            diagnosis[3] = "Нормальный";
            diagnosis[4] = "Талант";
            diagnosis[5] = "Гений";

            var numberDiagnosis = 0;

            var percentRightAnswers = user.CountAnswer * 100 / countQuestions;
            if (percentRightAnswers >= 0 && percentRightAnswers <= 16)
            {
                numberDiagnosis = 0; //Идиот
            }
            if (percentRightAnswers > 16 && percentRightAnswers <= 33)
            {
                numberDiagnosis = 1; //Кретин
            }
            if (percentRightAnswers > 33 && percentRightAnswers <= 49)
            {
                numberDiagnosis = 2; //Дурак
            }
            if (percentRightAnswers > 49 && percentRightAnswers <= 65)
            {
                numberDiagnosis = 3; //Нормальный
            }
            if (percentRightAnswers > 65 && percentRightAnswers <= 81)
            {
                numberDiagnosis = 4; //Талант
            }
            if (percentRightAnswers > 81 && percentRightAnswers <= 100)
            {
                numberDiagnosis = 5; //Гений
            }

            var diagnos = diagnosis[numberDiagnosis];
            user.Diagnose = diagnos;
            return user.Name + ", ваш диагноз: " + diagnos;
        }
    }  
}
