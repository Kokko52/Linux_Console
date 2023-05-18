using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Termin
{
    class rm
    {

        public string str;
        public string path = Environment.CurrentDirectory;
        public bool err()
        {
            // getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //list keys
            var list = new List<string>() { "--help", "*", "-r", "-d" };

            int check_key1 = 1;
            int check_key2 = 1;

            //add null elements
            #region
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
            #endregion

            //checking for keys
            for (int i = 0; i < list.Count; i++)
            {
                //rm
                if (element[1] == "")
                {
                    check_key1 = -1;
                    break;
                }
                if (str == "rm --help")
                {
                    return true;
                }
                //rm 'name'
                if (element[1] != "" && element[1][0] != '-' && element[2] == "")
                {
                    ++check_key1;
                    ++check_key2;
                    break;
                }
                //rm -d and -r
                if ((element[1] == "-r" || element[1] == "-d") && element[2] == "")
                {
                    check_key1 = -1;
                    break;
                }
                if (element[1][0] == '-' && element[2] == "")
                {
                    check_key1 = 0;
                    break;
                }
                //rm 'name' -r
                if (element[1] != "" && element[1][0] != '-' && element[2] != "-r" && element[2] != "-d")
                {
                    check_key1++;
                    check_key2 = 0;
                    break;
                }
                //rm -r 'name'
                if (element[1] != "-r" && element[1] != "-d" && element[2] != "" && element[2][0] != '-')
                {
                    check_key2++;
                    check_key1 = 0;
                    break;
                }
                //rm *
                if (element[1] == "*" && element[2] == "")
                {
                    ++check_key1;
                    ++check_key2;
                    break;
                }

            }
            //checking for option
            if (check_key1 == -1)
            {
                Console.WriteLine("\nrm: missing operand\r\nTry 'rm --help' for more information.\r\n");
                return false;
            }
            else if (check_key1 == -2)
            {
                Console.WriteLine("\nrm: cannot create directory\'" + element[1] + "\': No such file or directory\r\n");
                return false;
            }
            else if (check_key1 == 0)
            {
                Console.WriteLine("\nrm: unknown option -" + element[1] + "\n");
                return false;
            }
            if (check_key2 == 0)
            {
                Console.WriteLine("\nrm: unknown option -" + element[2] + "\n");
                return false;
            }
            return true;
        }
        public void begin()
        {
            try
            {
                //rm *  - удаление всх файлов
                //rm -r 'dir' - удаление dir и ее содерж
                //rm -d 'dir'- удаление пустых директорий

                // getting string elements
                string[] element = new string[] { };
                element = str.Split(' ');

                switch (element[1])
                {
                    case "--help":
                        {
                            help cls = new help();
                            cls.helping("rm");
                            Console.WriteLine();
                            break;
                        }
                    case "*":
                        {
                            //adding files from directory
                            string[] file = Directory.GetFiles(Environment.CurrentDirectory);
                            for (int i = 0; i < file.Length; ++i)
                            {
                                File.Delete(file[i]);
                            }
                            break;
                        }
                    case "-r":
                        {
                            try
                            {
                                Directory.Delete(Environment.CurrentDirectory + "\\" + element[2], true);
                            }
                            catch (System.IO.DirectoryNotFoundException) { Console.WriteLine("\nrm: cannot remove \'" + element[2] + "\': No such file or directory\n"); }

                            break;
                        }
                    case "-d":
                        {
                            try
                            {
                                Directory.Delete(Environment.CurrentDirectory + "\\" + element[2], false);
                            }
                            catch (System.IO.DirectoryNotFoundException) { Console.WriteLine("\nrm: cannot remove \'" + element[2] + "\': No such file or directory\n"); }
                            catch (System.IO.IOException) { Console.WriteLine("\nrm: cannot remove \'" + element[2] + "\': the folder is not empty\n"); }
                            break;
                        }
                    default:
                        {
                            //add null elements
                            if (element.ElementAtOrDefault(2) == null)
                            {
                                Array.Resize(ref element, element.Length + 1);
                                element[element.Length - 1] = "";
                            }

                            if (element[2] == "-r")
                            {
                                try
                                {
                                    Directory.Delete(Environment.CurrentDirectory + "\\" + element[1], true);
                                }
                                catch (System.IO.DirectoryNotFoundException) { Console.WriteLine("\nrm: cannot remove \'" + element[2] + "\': No such file or directory\n"); }
                                break;
                            }
                            else if (element[2] == "-d")
                            {
                                try
                                {
                                    Directory.Delete(Environment.CurrentDirectory + "\\" + element[1], false);
                                }
                                catch (System.IO.DirectoryNotFoundException) { Console.WriteLine("\nrm: cannot remove \'" + element[2] + "\': No such file or directory\n"); }
                                catch (System.IO.IOException) { Console.WriteLine("\nrm: cannot remove \'" + element[2] + "\': the folder is not empty\n"); }
                                break;
                            }
                            else
                            {
                                try
                                {
                                    File.Delete(Environment.CurrentDirectory + "\\" + element[1]);
                                }
                                catch (System.UnauthorizedAccessException) { Console.WriteLine("\nrm: cannot remove \'" + element[1] + "\': access denied\n"); }
                                catch (System.IO.DirectoryNotFoundException) { Console.WriteLine("\nrm: cannot remove \'" + element[1] + "\': No such file or file\n"); }
                                break;

                            }
                            break;
                        }
                }
           }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
