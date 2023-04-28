using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class cd
    {
        public string str;
        public static string directory_path = Environment.CurrentDirectory;
        public string keys()
        {
            /*  [0] - commad
                [1] - directory  */
            string[] element = str.Split(' '); //получение отдельных элементов строки
            string path = "";
            try
            {
                Directory.SetCurrentDirectory(element[1]);
                path = Directory.GetCurrentDirectory();
                var info = new DirectoryInfo(directory_path);
            }
            catch
            {
                Console.WriteLine("No such directory");
            }
            return path;
        }
    }
}
