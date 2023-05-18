using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class cat
    {
        public string str;
        public string path = Environment.CurrentDirectory;
        public bool err()
        {
            // getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //list keys
            var list = new List<string>() { "--help", "-E", "-n", "-b" };

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
            if (element.ElementAtOrDefault(3) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }

            //checking for keys
            int ch_E = 0;
            int ch_n = 0;
            int ch_b = 0;
            for (int i = 0; i < list.Count; i++)
            {
                //found -E
                if (str.Contains("-E"))
                {
                    for (int j = 0; j < element.Length; ++j)
                    {
                        if (element[j] == "-E")
                        {
                            ++ch_E;
                            break;
                        }
                    }
                    if (ch_E == 0)
                    {
                        Console.WriteLine("rmdir: ambiguous option -- E\nTry \'cat --help\' for more information.");
                        return false;
                    }
                    else { }
                    ++check_key1;
                    ++check_key2;
                }
                if (str.Contains("-n"))
                {
                    for (int j = 0; j < element.Length; ++j)
                    {
                        if (element[j] == "-n")
                        {
                            ++ch_n;
                            break;
                        }
                    }
                    if (ch_n == 0)
                    {
                        Console.WriteLine("rmdir: ambiguous option -- n\nTry \'cat --help\' for more information.");
                        return false;
                    }
                    else { }
                    ++check_key1;
                    ++check_key2;
                    break;
                }
                if (str.Contains("-b"))
                {
                    for (int j = 0; j < element.Length; ++j)
                    {
                        if (element[j] == "-b")
                        {
                            ++ch_b;
                            break;
                        }
                    }
                    if (ch_b == 0)
                    {
                        Console.WriteLine("rmdir: ambiguous option -- b\nTry \'cat --help\' for more information.");
                        return false;
                    }
                    else { }
                    ++check_key1;
                    ++check_key2;
                    break;
                }
                //cat
                if (element[1] == "")
                {
                    ++check_key1;
                    ++check_key2;
                    break;
                }
                //cat 'name'
                if (element[1] != "" && element[1][0] != '-')
                {
                    ++check_key1;
                    ++check_key2;
                    break;
                }
                //mkdir --help
                if (element[1] == "--help")
                {
                    ++check_key1;
                    ++check_key2;
                    break;
                }
                //cat not(-E -n -b)
                if (element[1] != "-E" && element[1] != "-n" && element[1] != "-b")
                {
                    break;
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
        public void return_(string element, string option = "")
        {
            try
            {
                int check = 0;
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + element))
                {
                    string input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        string str = Convert.ToString(input);
                        if (option == "E")
                        {
                            ++check;
                            Console.WriteLine("$    " + str);
                        }
                        else if (option == "only_n")
                        {
                            ++check;
                            Console.WriteLine(check + "    " + str);
                        }
                        else if (option == "null")
                        {
                            Console.WriteLine(str);
                        }
                        else
                        {
                            ++check;
                            Console.WriteLine("$    " + check + "    " + str);

                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
        public void return_b(string element, string option = "")
        {
            try
            {
                int check = 0;
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + element))
                {
                    string input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        string str = Convert.ToString(input);
                        if (option == "only_b")
                        {
                            if (str == "")
                            {
                                Console.WriteLine("    " + str);
                            }
                            else
                            {
                                ++check;
                                Console.WriteLine(check + "    " + str);
                            }
                        }
                        else
                        {
                            if (str == "")
                            {
                                Console.WriteLine("$    " + "    " + str);
                            }
                            else
                            {
                                ++check;
                                Console.WriteLine("$    " + check + "    " + str);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

        public void begin()
        {
            try
            {
                //getting string elements
                string[] element = new string[] { };
                element = str.Split(' ');
                int ch = 0;
                //find file_name
                string name_file = "";
                while (ch < element.Length)
                {
                    if (element[ch].Contains(".txt"))
                    {
                        name_file = element[ch];
                    }
                    ++ch;
                }
                try
                {
                    if (str == "cat --help")
                    {
                        help cls = new help();
                        cls.helping("cat");
                        Console.WriteLine();
                        return;
                    }
                    #region return
                    if (str.Contains("-E") && str.Contains("-n"))
                    {
                        return_(name_file);
                    }
                    else if (str.Contains("-E") && str.Contains("b"))
                    {
                        return_b(name_file);
                    }
                    else if (str.Contains("-E"))
                    {
                        return_(name_file, "E");
                    }
                    else if (str.Contains("-n"))
                    {
                        return_(name_file, "only_n");
                    }
                    else if (str.Contains("-b"))
                    {
                        return_b(name_file, "only_b");
                    }
                    else
                    {
                        return_(name_file, "null");
                    }
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    Console.WriteLine("cat: " + name_file + ": No such file or directory\r\n");
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("cat: " + name_file + ": No such file or directory\r\n");
                }
                #endregion
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
