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
        public static string options1;
        public static string options2;
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
                //full string
                string str = Console.ReadLine();
                //command
                string str_command = str.Split(' ')[0];
                //parts string
                string[] qwe = str.Split(' ');
                switch (str_command)
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
                            cls.str = str;
                            if (cls.err())
                            {
                                Console.WriteLine("\t");
                                cls.begin();
                                Console.WriteLine("\t");
                            }
                            break;
                        }
                    #endregion
                    #region pwd
                    case "pwd":
                        {
                            pwd cls = new pwd();
                            Console.WriteLine("\t");
                            cls.rec();
                            Console.WriteLine("\t");
                            break;
                        }
                    #endregion
                    #region cd
                    case "cd":
                        {
                            cd cls = new cd();
                            cls.str = str;
                            directory_path = cls.keys();
                            break;
                        }
                    #endregion
                    #region mkdir
                    case "mkdir":
                        {
                            mkdir cls = new mkdir();
                            cls.str = str;
                            if(cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region rmdir
                    case "rmdir":
                        {
                            try
                            {
                                //  options1 = str[1];
                                //   options2 = str[2];
                                rmdir cls = new rmdir();
                                cls.keys(options1);
                            }
                            catch
                            {
                                if (options1 != null)
                                {
                                    rmdir cls = new rmdir();
                                    cls.keys(options1);
                                }
                                else
                                    Console.WriteLine("\nrmdir: missing operand\n" +
                                    "Try 'rmdir --help' for more information.\n");
                            }
                            break;
                        }
                    #endregion
                    #region command not found
                    default:
                        Console.WriteLine("command not found");
                        break;
                        #endregion
                }
            }

        }
    }
}
