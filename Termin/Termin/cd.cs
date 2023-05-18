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
            string path = "";
            try
            {
                /*  [0] - commad
                    [1] - directory  */
                string[] element = str.Split(' '); //получение отдельных элементов строки
                
                try
                {
                    if (str == "cd --help")
                    {
                        help cls = new help();
                        cls.helping("cd");
                        Console.WriteLine();
                        return "";
                    }
                    if (element.Length == 1)
                    {
                        Directory.SetCurrentDirectory(directory_path.Split('\\')[0] + "\\");
                        path = Directory.GetCurrentDirectory();
                        var info1 = new DirectoryInfo(directory_path);
                    }
                    else
                    {
                        Directory.SetCurrentDirectory(element[1]);
                        path = Directory.GetCurrentDirectory();
                        var info = new DirectoryInfo(directory_path);
                    }
                }
                catch
                {
                    path = Environment.CurrentDirectory;
                    Console.WriteLine("No such directory");
                    return path;
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
            return path;
        }
    }
}
