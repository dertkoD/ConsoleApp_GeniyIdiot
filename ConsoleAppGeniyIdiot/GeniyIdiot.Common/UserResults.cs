using System;
using System.Collections.Generic;
using System.Text;

namespace GeniyIdiot.Common
{
    class UserResults
    {
        public static string Way = "UserResults.txt";

        public static void Save(User user)
        {
            var information = user.Name + ";" + user.CountAnswer + ";" + user.Diagnose + "\n";
            FileProvide.Save(Way, information);
        }

        public static List<User> GettAll()
        {
            var information = FileProvide.Get(Way);
            var lines = information.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);


            var users = new List<User>();

            foreach (var line in lines)
            {
                var data = line.Split(';');

                var user = new User(data[0]);
                user.CountAnswer = Convert.ToInt32(data[1]);
                user.Diagnose = data[2];

                users.Add(user);
            }

            return users;
        }
    }
}
