using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class Program
    {
        public static string key1;
        public static string key2;
        public static string key3;
        public static string console;
        public static string directory_path = Environment.CurrentDirectory;
        public static string path;
        static void Main(string[] args)
        {

            while (true)
            {
                //string[] directory_name = (Environment.CurrentDirectory).Split('\\');
                //int int_dir = directory_name.Length - 1;
                //directory_path= Environment.CurrentDirectory;
                path = " ";
                console = "[" + Environment.UserName + "@" + Environment.UserDomainName + " " + directory_path + "] ";
                Console.Write(console);
                string[] str = Console.ReadLine().Split(' ');
                switch (str[0])
                {
                    #region man
                    case "man":
                        {
                            man cls = new man();
                            // cls.str = str;
                            cls.err();
                            //bool hlp = cls.help();
                            //bool key1 = cls.key_1();
                            //bool key2 = cls.key_2();
                            //bool key3 = cls.key_3();
                            //cls.print();
                            break;
                        }
                    #endregion
                    #region ls
                    case "ls":
                        {
                            ls cls = new ls();

                            if (str.Length == 1)
                            {
                                cls.rec();
                            }
                            else if (str.Length > 2)
                            {
                                key1 = str[1];
                                key2 = str[2];
                                if (cls.keys(key1, key2))
                                {
                                    cls.rec(key1, key2);
                                }
                            }
                            else
                            {
                                key1 = str[1];
                                if (cls.keys(key1))
                                {
                                    cls.rec(key1);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region pwd
                    case "pwd":
                        {
                            pwd cls = new pwd();
                            cls.rec();
                            break;
                        }
                    #endregion
                    case "cd":
                        {
                           try
                           {
                                string dir = str[1];
                                cd cls = new cd();

                              directory_path = cls.keys(dir, directory_path);
                           }
                           catch (System.IndexOutOfRangeException)
                           {
                               directory_path = "~";
                               Console.WriteLine("");
                           }
                            break;
                        }
                    case "mkdir":
                        {
                            try
                            {
                               string options1 = str[1];
                               string options2 = str[2];
                                mkdir cls = new mkdir();
                                cls.keys(options1, directory_path);
                            }
                            catch (System.IndexOutOfRangeException)
                            {
                                Console.WriteLine("\nmkdir: missing operand\n" + 
                                "Try \'mkdir --help\' for more information\n");
                            }
                            break;
                        }
                    case "rmdir":
                        {
                            break;
                        }
                    default:
                        Console.WriteLine("command not found");
                        break;
                }
            }

        }
    }
}
