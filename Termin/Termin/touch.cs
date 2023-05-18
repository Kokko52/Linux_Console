using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Termin
{
    internal class touch
    {
        //touch -m 'name'
        //-r 'name1' 'name2'\
        //-c
        //-m

        //current path
        public string path = Environment.CurrentDirectory;
        //original string
        public string str;
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
            var list = new List<string>() { "--help", "-m", "-c", "-r" };

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //touch
                if (element[1] == "")
                {
                    Console.WriteLine("\ntouch: missing operand\r\nTry 'touch --help' for more information.\r\n");
                    return false;
                }
                if (str == "touch --help")
                {
                    return true;
                }
                //touch 'name'
                if (element[1] != "" && element[1][0] != '-')
                {
                    return true;
                }

                //if there is a key
                if (element[1] == list[i])
                {
                    if (element[1] == "-r")
                    {
                        //touch -r ''
                        if (element[2] == "")
                        {
                            Console.WriteLine("\ntouch: missing operand\r\nTry 'touch --help' for more information.\r\n");
                            return false;
                        }
                        //touch -r 'name' ''
                        if (element[3] == "")
                        {
                            Console.WriteLine("\ntouch: missing operand\r\nTry 'touch --help' for more information.\r\n");
                            return false;
                        }
                    }
                    //touch -key ''
                    if (element[2] == "")
                    {
                        Console.WriteLine("\ntouch: missing operand\r\nTry 'touch --help' for more information.\r\n");
                        return false;
                    }
                    ++check;
                }

            }
            //errors
            if (check == 0)
            {
                Console.WriteLine("\ntouch: unknown option - " + element[1] + "\r\nTry 'touch --help' for more information.\n");
                return false;
            }
            return true;
        }
        public void begin()
        {
            try
            {
                switch (element[1])
                {
                    case "--help":
                        {
                            help cls = new help();
                            cls.helping("touch");
                            Console.WriteLine();
                            break;
                        }
                    case "-m":
                        {
                            //if file 1 no exists
                            if (!File.Exists(element[2]))
                            {
                                File.Create(element[2]);
                            }
                            else
                            {


                                File.SetLastWriteTime(element[2], DateTime.Now);

                            }

                            break;
                        }
                    case "-c":
                        {
                            if (File.Exists(element[2]))
                            {

                            }
                            else
                            {

                            }
                            break;
                        }
                    case "-r":
                        {
                            try
                            {
                                //if file 1 no exists
                                if (!File.Exists(element[2]))
                                {
                                    Console.WriteLine("\ntouch: " + element[2] + ": No such file or directory\r\n");
                                    return;
                                }
                                //if file 2 no exists
                                if (!File.Exists(element[3]))
                                {
                                    File.Create(element[3]);
                                }
                                File.SetLastWriteTime(element[3], File.GetLastWriteTime(element[2]));
                            }
                            catch (Exception e) { }
                            break;
                        }
                    default:
                        {
                            try
                            {
                                if (element[1].Contains(".txt"))
                                {
                                    File.Create(element[1]);
                                }
                                else
                                {
                                    Console.WriteLine("touch: unable to create a directory");
                                }
                            }
                            catch (Exception e) { Console.WriteLine(element[1] + " - directory"); }
                            break;
                        }
                }

            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
