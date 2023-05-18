using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    /* 
     * rmdir
     * rmdir -p 'dir'
     * rmdir -v 'dir' and rmdir -p -v 'dir'
     * 
     *  mkdir - [0]
     * -key1  - [1]
     * -key2  - [2]
     */
    class rmdir
    {
        public string str;
        public string path = Environment.CurrentDirectory;
        public bool err()
        {
            //getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //list keys
            var list = new List<string>() { "--help", "-p", "-v" };

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
            int ch = 0;
            for (int i = 0; i < list.Count; i++)
            {
                //found -v
                if (str.Contains("-v"))
                {
                    for (int j = 0; j < element.Length; ++j)
                    {
                        if (element[j] == "-v")
                        {
                            ++ch;
                            break;
                        }
                    }
                    if (ch == 0)
                    {
                        Console.WriteLine("rmdir: ambiguous option -- v\nTry \'rmdir --help\' for more information.");
                        return false;
                    }
                    else
                    {
                    }
                    ++check_key1;
                    ++check_key2;
                    break;
                }

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
                    break;
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
                    break;
                }
                if (element[1] == list[i] && element[2] == list[i])
                {
                    check_key1 = -1;
                    break;
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
                            cls.helping("rmdir");
                            Console.WriteLine();
                            break;
                        }
                    case "-p":
                        {
                            if (str.Contains("-v"))
                            {
                                if (element[2] == "-v")
                                {
                                    try
                                    {
                                        Directory.Delete(path + "\\" + element[3]);
                                        Console.WriteLine("\nrmdir: removing directory, \'" + element[3] + "\'\n");
                                    }
                                    catch (System.IO.DirectoryNotFoundException)
                                    {
                                        Console.WriteLine("\nrmdir: failed to remove \'" + element[3] + "\': No such file or directory\r\n");
                                    }
                                    catch (System.IO.IOException)
                                    {
                                        Console.WriteLine("\nrmdir: failed to remove \'" + element[3] + "\': Directory not empty\r\n");
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        Directory.Delete(path + "\\" + element[2]);
                                        Console.WriteLine("\nrmdir: removing directory, \'" + element[2] + "\'\n");
                                    }
                                    catch (System.IO.DirectoryNotFoundException)
                                    {
                                        Console.WriteLine("\nrmdir: failed to remove \'" + element[2] + "\': No such file or directory\r\n");
                                    }
                                    catch (System.IO.IOException)
                                    {
                                        Console.WriteLine("\nrmdir: failed to remove \'" + element[2] + "\': Directory not empty\r\n");
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    Directory.Delete(path + "\\" + element[2], true);
                                }
                                catch (System.IO.DirectoryNotFoundException)
                                {
                                    Console.WriteLine("\nrmdir: failed to remove \'" + element[2] + "\': No such file or directory\r\n");
                                }
                                catch (System.IO.IOException)
                                {
                                    Console.WriteLine("\nrmdir: failed to remove \'" + element[2] + "\': Directory not empty\r\n");
                                }
                            }
                            break;
                        }
                    case "-v":
                        {
                            if (element[2] == "-p")
                            {
                                try
                                {
                                    Directory.Delete(path + "\\" + element[3], true);
                                    Console.WriteLine("\nrmdir: removing directory, \'" + element[3] + "\'\n");
                                }
                                catch (System.IO.DirectoryNotFoundException)
                                {
                                    Console.WriteLine("\nrmdir: failed to remove \'" + element[3] + "\': No such file or directory\r\n");
                                }
                                catch (System.IO.IOException)
                                {
                                    Console.WriteLine("\nrmdir: failed to remove \'" + element[3] + "\': Directory not empty\r\n");
                                }
                            }
                            else
                            {
                                try
                                {
                                    Directory.Delete(path + "\\" + element[2]);
                                    Console.WriteLine("\nrmdir: removing directory, \'" + element[2] + "\'\n");
                                }
                                catch (System.IO.DirectoryNotFoundException)
                                {
                                    Console.WriteLine("\nrmdir: failed to remove \'" + element[2] + "\': No such file or directory\r\n");
                                }
                                catch (System.IO.IOException)
                                {
                                    Console.WriteLine("\nrmdir: failed to remove \'" + element[2] + "\': Directory not empty\r\n");
                                }
                            }
                            break;
                        }
                    default:
                        {
                            try
                            {
                                Directory.Delete(path + "\\" + element[1]);
                            }
                            catch (System.IO.IOException)
                            {
                                Console.WriteLine("\nrmdir: failed to remove \'" + element[1] + "\': Directory not empty\r\n");
                            }
                            break;
                        }
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

    }
}
