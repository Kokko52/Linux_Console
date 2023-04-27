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
        static void Main(string[] args)
        {

            while (true)
            {
                string[] directory_name = (Environment.CurrentDirectory).Split('\\');
                int int_dir = directory_name.Length - 1;
                Console.Write("[" + Environment.UserName + "@" + Environment.UserDomainName + " " + directory_name[int_dir] + "] ");
                string[] str = Console.ReadLine().Split(' ');
                switch (str[0])
                {
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
                    case "pwd":
                        {
                            pwd cls = new pwd();
                            cls.rec();
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
