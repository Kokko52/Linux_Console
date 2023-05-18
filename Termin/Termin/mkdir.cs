using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class mkdir
    {
        /* 
         * mkdir
         * mkdir -p 'dir' and mkdir 'name' -p    
         * 
         *  mkdir - [0]
         * -key1  - [1]
         * -key2  - [2]
         */

        public string str;
        public string path = Environment.CurrentDirectory;
        public bool err()
        {
            // getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //list keys
            var list = new List<string>() { "--help", "-p" };

            int check_key1 = 0;
            int check_key2 = 0;

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

            //checking for keys
            for (int i = 0; i < list.Count; i++)
            {
                //mkdir
                if (element[1] == "")
                {
                    check_key1 = -1;
                    break;
                }
                //mkdir --help
                if (element[1] == "--help")
                {
                    ++check_key1;
                    ++check_key2;
                }
                //mkdir 'name'
                if (element[1] != "" && element[2] == "")
                {
                    ++check_key1;
                    ++check_key2;
                }
                //mkdir 'name/name'
                if (element[1].Contains('/') && element[2] == "")
                {
                    check_key1 = -2;
                    break;
                }
                //mkdir -p
                if (element[1] == list[i] && element[2] == "")
                {
                    check_key1 = -1;
                }
                if (element[1] == list[i] && element[2] == "-p")
                {
                    check_key1 = -1;
                }
                //mkdir -p 'name'
                if (element[1] == list[i] && element[2] != "")
                {
                    ++check_key1;
                    ++check_key2;
                }
                //mkdir 'name' -p
                if (element[1] != "" && element[2] == "-p")
                {
                    ++check_key1;
                    ++check_key2;
                }
            }

            //checking for option
            if (check_key1 == -1)
            {
                Console.WriteLine("\nmkdir: missing operand\r\nTry 'mkdir --help' for more information.\r\n");
                return false;
            }
            else if (check_key1 == -2)
            {
                Console.WriteLine("\nmkdir: cannot create directory\'" + element[1] + "\': No such file or directory\r\n");
                return false;
            }
            else if (check_key1 == 0)
            {
                Console.WriteLine("\nmkdir: unknown option -" + element[1]);
                return false;
            }
            if (check_key2 == 0)
            {
                Console.WriteLine("\nmkdir: unknown option -" + element[2]);
                return false;
            }

            return true;
        }
        public void begin()
        {
            try
            {
                //getting string elements
                string[] element = new string[] { };
                element = str.Split(' ');

                //adding null elements
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

                switch (element[1])
                {
                    case "--help":
                        {
                            help cls = new help();
                            cls.helping("mkdir");
                            Console.WriteLine();
                            break;
                        }
                    case "-p":
                        {
                            string[] files = Directory.GetDirectories(path);
                            #region checking for files
                            for (int i = 0; i < files.Length; i++)
                            {
                                string name_old_directory = Path.GetFileName(files[i]);
                                if (name_old_directory == element[2])
                                {
                                    Console.WriteLine("mkdir: cannot create directory \'" + element[2] + "\': File exists");
                                    break;
                                }
                            }
                            #endregion
                            try
                            {
                                Directory.CreateDirectory(path + "\\" + element[2]);
                            }
                            catch (System.IO.DirectoryNotFoundException) { Console.WriteLine("\nmkdir: cannot remove \'" + element[2] + "\': No such file or directory\n"); }
                            break;
                        }

                    default:
                        {
                            string[] files = Directory.GetDirectories(path);
                            #region checking for files
                            for (int i = 0; i < files.Length; i++)
                            {
                                string name_old_directory = Path.GetFileName(files[i]);
                                if (name_old_directory == element[1])
                                {
                                    Console.WriteLine("mkdir: cannot create directory \'" + element[2] + "\': File exists");
                                    break;
                                }
                            }
                            #endregion
                            Directory.CreateDirectory(path + "\\" + element[1]);
                            break;
                        }
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
