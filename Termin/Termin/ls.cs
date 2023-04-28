using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace Termin
{
    internal class ls
    {
        /* 
         * ls -a
         * ls -r
         * ls -X - error
         * 
         *  ls   - [0]
         * -key1 - [1]
         * -key2 - [2]
         */

        public string key1, key2;
        public string str;
        public bool err()
        {
            //getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //list keys
            var list = new List<string>() { "--help", "-a", "-r", "-X" };

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
                if (element[1] == list[i] || element[1] == "")
                {
                    ++check_key1;
                }
                if (element[2] == list[i] || element[2] == "")
                {
                    ++check_key2;
                }
            }

            //checking for option
            if (check_key1 == 0)
            {
                Console.WriteLine("ls: unknown option -" + element[1]);
                return false;
            }
            if (check_key2 == 0)
            {
                Console.WriteLine("ls: unknown option -" + element[2]);
                return false;
            }
            return true;
        }
        public void begin()     
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
            //adding files from directory
            string[] file = Directory.GetFileSystemEntries(Environment.CurrentDirectory);
            List<string> ls = new List<string>(file);

            switch (element[1])
            {
                case "--help":
                    {
                        string path_man = Directory.GetCurrentDirectory().Replace("bin\\Debug", "") + "man\\ls.txt";
                        using (StreamReader sr = new StreamReader(path_man))
                        {
                            Console.WriteLine(sr.ReadToEnd());
                        }
                        break;
                    }
                case "-a":
                    {
                        if (element[2] == "" || element[2] == "-a")
                        {
                            foreach (string list in ls)
                            {
                                Console.WriteLine(Path.GetFileName(list));
                            }
                            return;
                        }
                        else if (element[2] == "-r")
                        {
                            ls.Sort();
                            ls.Reverse();
                            foreach (string list in ls)
                            {
                                Console.WriteLine(Path.GetFileName(list));
                            }
                            return;
                        }
                        else if (element[2] == "-X")
                        {
                            ls.Sort();
                            foreach (string list in ls)
                            {
                                Console.WriteLine(Path.GetFileName(list));
                            }
                            return;
                        }
                        break;
                    }
                case "-r":
                    {
                        if (element[2] == "" || element[2] == "-r" || element[2] == "-X")
                        {
                            ls.Sort();
                            ls.Reverse();
                            foreach (string list in ls)
                            {
                                if ((File.GetAttributes(list) & FileAttributes.Hidden) == FileAttributes.Hidden)
                                { }
                                else
                                    Console.WriteLine(Path.GetFileName(list));
                            }
                            return;
                        }
                        else if (element[2] == "-a")
                        {
                            ls.Sort();
                            ls.Reverse();
                            foreach (string list in ls)
                            {
                                Console.WriteLine(Path.GetFileName(list));
                            }
                            return;
                        }                
                        break;
                    }
                case "-X":
                    {
                        if (element[2] == "" || element[2] == "-X" || element[2] == "-r")
                        {
                            ls.Sort();
                            foreach (string list in ls)
                            {
                                if ((File.GetAttributes(list) & FileAttributes.Hidden) == FileAttributes.Hidden)
                                { }
                                else
                                    Console.WriteLine(Path.GetFileName(list));
                            }
                            return;
                        }
                        else if (element[2] == "-a")
                        {
                            ls.Sort();
                            foreach (string list in ls)
                            {
                                Console.WriteLine(Path.GetFileName(list));
                            }
                            return;
                        }
                        break;
                    }
                default:
                    {
                        foreach (string list in ls)
                        {
                            if ((File.GetAttributes(list) & FileAttributes.Hidden) == FileAttributes.Hidden)
                            { }
                            else
                                Console.WriteLine(Path.GetFileName(list));
                        }
                        break;
                    }
            }

        }
       
    }
}
