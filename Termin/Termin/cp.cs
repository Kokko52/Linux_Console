using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class cp
    {

        //-n -если файл сущ, то отбой, а если нет, то создает и записывает
        //-i - спрашивать, нужно ли перезаписывать существующие файлы;
        //-f, --force - удалить файл назначения перед попыткой записи в него если он существует;

        //original string
        public string str;
        //current dir
        public string path = Environment.CurrentDirectory;
        //list elements
        public static string[] element = new string[] { };
        public bool err()
        {
            // getting string elements
            element = str.Split(' ');

            //add null elements
            if (element.ElementAtOrDefault(1) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }
            if (element.ElementAtOrDefault(2) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }
            if (element.ElementAtOrDefault(3) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }

            //number of keys found
            int check = 0;

            //list keys
            var list = new List<string>() { "--help", "-n", "-i", "-f" };

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //cp
                if (element[1] == "")
                {
                    Console.WriteLine("\ncp: missing operand\r\nTry 'cp --help' for more information.\r\n");
                    return false;
                }
                //cp 'name1' 'name2'
                if (element[1] != "" && element[1][0] != '-' && element[2] != "" && element[2][0] != '-')
                {
                    return true;
                }
                //if there is a key
                if (element[1] == list[i])
                {
                    //cp --help
                    if(element[1] == "--help")
                    {
                        return true;
                    }
                    //finding names files
                    if (element[2] != "" && element[2][0] != '-' && element[3] != "" && element[3][0] != '-')
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\ncp: missing operand\r\nTry 'cp --help' for more information.\r\n");
                        return false;
                    }
                }
            }

            //errors
            if (check == 0)
            {
                Console.WriteLine("\ncp: unknown option - " + element[1] + "\r\nTry 'cp --help' for more information.\n");
                return false;
            }

            return true;
        }
        public void begin()
        {
            if(str == "cp --help")
            {
                help cls = new help();
                cls.helping("cp");
                Console.WriteLine();
                return;
            }
            //if file 1 no exists
            if (!File.Exists(element[2]))
            {
                Console.WriteLine("\ncp: " + element[2] + ": No such file or directory\r\n");
                return;
            }

            switch (element[1])
            {
                
                case "-n":
                    {
                        //if the file exists
                        if (!File.Exists(element[3]))
                        {
                            //copy file
                            File.Copy(element[2], element[3], true);
                        }
                        else
                        {
                        }
                        break;
                    }
                case "-i":
                    {
                        //if the file exists
                        if (File.Exists(element[3]))
                        {
                            Console.WriteLine("input(y/n)");

                            //input
                            string inp = Console.ReadLine();
                            if (inp == "y")
                            {
                                //copy file
                                File.Copy(element[2], element[3], true);
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                        break;
                    }
                case "-f":
                    {
                        //if the file exists
                        if (File.Exists(element[3]))
                        {
                            //delete fil
                            File.Delete(element[3]);

                            //copy file
                            File.Copy(element[2], element[3], true);
                        }
                        else
                        {
                            //copy file
                            File.Copy(element[2], element[3], true);
                        }
                        break;
                    }
                default:
                    {
                        //if file 1 no exists
                        if (!File.Exists(element[1]))
                        {
                            Console.WriteLine("\ncp: " + element[2] + ": No such file or directory\r\n");
                            return;
                        }
                        //if file 2 no exists
                        if (!File.Exists(element[2]))
                        {
                            Console.WriteLine("\ncp: " + element[2] + ": No such file or directory\r\n");
                            return;
                        }

                        //copy file
                        File.Copy(element[1], element[2], true);
                        break;
                    }
            }
        }
    }
}
