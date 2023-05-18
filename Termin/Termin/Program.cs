using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                            cls.str = str;
                            if(cls.err())
                            {
                                cls.begin();
                            }
                            
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
                            cls.str = str;
                            cls.begin();
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
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region rmdir
                    case "rmdir":
                        {
                            rmdir cls = new rmdir();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region cat
                    case "cat":
                        {
                            cat cls = new cat();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region exit
                    case "exit":
                        {
                            exit cls = new exit();
                            cls.str = str;
                            cls.begin();
                            break;
                        }
                    #endregion
                    #region arch
                    case "arch":
                        {
                            if(str == "arch --help")
                            {
                                help cls = new help();
                                cls.helping("arch");
                                Console.WriteLine();
                                break;
                            }
                            Console.WriteLine(Environment.Is64BitOperatingSystem ? "x64" : "x32");
                            break;
                        }
                    #endregion
                    #region touch
                    case "touch":
                        {
                            touch cls = new touch();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region rm
                    case "rm":
                        {
                            //rm *  - удаление всх файлов
                            //rm -r 'dir' - удаление dir и ее содерж
                            //rm -d - удаление пустых директорий
                            rm cls = new rm();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region clear
                    case "clear":
                        {
                            if (str == "clear --help")
                            {
                                help cls = new help();
                                cls.helping("clear");
                                Console.WriteLine();
                                break;
                            }
                            Console.Clear();
                            break;
                        }
                    #endregion
                    #region date
                    case "date":
                        {
                            date cls = new date();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region head
                    case "head":
                        {
                            head cls = new head();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region ps
                    case "ps":
                        {
                            ps cls = new ps();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region uname
                    case "uname":
                        {
                            uname cls = new uname();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }

                            break;
                        }
                    #endregion
                    #region tail
                    case "tail":
                        {
                            tail cls = new tail();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region wc
                    case "wc":
                        {
                            wc cls = new wc();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region du
                    case "du":
                        {
                            du cls = new du();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region cp
                    case "cp":
                        {
                            cp cls = new cp();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    case "kill":
                        {
                            kill cls = new kill();
                            cls.str = str;
                            if(cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #region df
                    case "df":
                        {
                            df cls = new df();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    #region pwgen
                    case "pwgen":
                        {
                            pwgen cls = new pwgen();
                            cls.str = str;
                            if (cls.err())
                            {
                                cls.begin();
                            }
                            break;
                        }
                    #endregion
                    case "hexdump":
                        {
                            hexdump cls = new hexdump();
                            cls.HEXDUMP(path + "\\" + qwe[1]);
                            break;
                        }
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
