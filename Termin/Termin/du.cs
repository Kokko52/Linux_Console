using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    /*
     *-a, --all - выводить размер для всех файлов, а не только для директорий, по умолчанию размер выводится только для папок;
     *-s, --summarize - выводить только общий размер;
     *-h, --human-readable - выводить размер в единицах измерения удобных для человека;
     */

    internal class du
    {
        //du -a
        public static bool key_a = false;
        //du -s
        public static bool key_s = false;
        //du
        public static bool key_ = false;
        //original string
        public string str;
        //current path
        public string path = Environment.CurrentDirectory;
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
            var list = new List<string>() { "--help", "-a", "-h", "-s" };
            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //du
                if (element[1] == "")
                {
                    return true;
                }
                //if there is a key
                if (element[1] == list[i])
                {
                    check++;
                }
            }
            //errors
            if (check == 0)
            {
                Console.WriteLine("\ndu: unknown option - " + element[1] + "\r\nTry 'du --help' for more information.\n");
                return false;
            }
            return true;
        }
        public void begin()
        {
            switch (element[1])
            {
                case "--help":
                    {
                        help cls = new help();
                        cls.helping("du");
                        Console.WriteLine();
                        break;
                    }
                case "-a":
                    {
                        key_a = true;
                        ListAllFiles(path);
                        key_a = false;
                        break;
                    }
                case "-h":
                    {
                        ListAllFiles(path);
                        break;
                    }
                case "-s":
                    {
                        key_s = true;
                        ListAllFiles(path);
                        key_s = false;
                        break;
                    }
                default:
                    {
                        key_ = true;
                        ListAllFiles(path);
                        key_ = false;
                        break;
                    }
            }
        }
        public static void ListAllFiles(string path)
        {
            long full_size = 0;
            try
            {
                // listing all files
                string[] folders = Directory.GetFileSystemEntries(path);

                foreach (string folder in folders)
                {
                    //if file = directory
                    if (Directory.Exists(folder))
                    {
                        //if du -a
                        if (key_a)
                        {
                            Console.WriteLine(GetDirectorySize(folder) +"\t"+Path.GetFileName(folder));
                        }
                        else
                        {
                            //if du -s
                            if (key_s)
                            {
                                full_size += GetDirectorySize(folder);
                            }
                            else
                            {
                                Console.WriteLine(GetDirectorySize(folder) / 1000+"K \t"+Path.GetFileName(folder));
                            }

                        }
                    }
                    else
                    {
                        //if du
                        if (key_)
                        {

                        }
                        else
                        {
                            //if du -a
                            if (key_a)
                            {
                                Console.WriteLine(new FileInfo(folder).Length+" \t"+Path.GetFileName(folder));
                            }
                            else
                            {
                                //if du -s
                                if (key_s)
                                {
                                    full_size += new FileInfo(folder).Length;
                                }
                                else
                                {
                                    Console.WriteLine(new FileInfo(folder).Length / 1000+"K \t"+Path.GetFileName(folder));
                                }
                            }
                        }
                    }
                }
                //if du -s
                if (key_s)
                {
                    Console.WriteLine("\n"+full_size+"\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
        }
        public static long GetDirectorySize(string path)
        {
            long size = 0;

            // listing files
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                size += new FileInfo(file).Length;
            }

            // listing dir
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                size += GetDirectorySize(folder);
            }
            return size;
        }
    }
}
