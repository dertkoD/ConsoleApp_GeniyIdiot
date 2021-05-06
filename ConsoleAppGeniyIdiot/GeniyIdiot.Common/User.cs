using System;
using System.Collections.Generic;
using System.Text;

namespace GeniyIdiot.Common
{
    public class User
    {
        public string Name;
        public int CountAnswer;
        public string Diagnose;

        public User(string name)
        {
            Name = name;
            CountAnswer = 0;
            Diagnose = "Неизвестно";
        }
    }
}
