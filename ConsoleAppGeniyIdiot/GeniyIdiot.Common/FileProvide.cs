using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeniyIdiot.Common
{
    public class FileProvide
    {
        public static void Save(string path, string value)
        {
            StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8);
            writer.Write(value);
            writer.Close();
        }

        public static string Get(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.UTF8);
            var value = reader.ReadToEnd();
            reader.Close();

            return value;
        }

        public static bool IsExists(string path)
        {
            return File.Exists(path);
        }
    }
}
