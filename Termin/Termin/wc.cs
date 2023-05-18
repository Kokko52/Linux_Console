using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class wc
    {
        //original string
        public string str;
        //file .txt
        public string file_name;
        //list elements
        public static string[] element = new string[] { };
        //list strings
        public string[] list_string = new string[] { };
        //list words
        public string[] list_words = new string[] { };
        // getting string elements

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

            //number of keys found
            int check = 0;

            //list keys
            var list = new List<string>() { "--help", "-l", "-w", "-m" };

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //wc
                if (element[1] == "")
                {
                    Console.WriteLine("\nwc: missing operand\r\nTry 'wc --help' for more information.\r\n");
                    return false;
                }
                if(str == "wc --help")
                {
                    return true;
                }
                //wc 'name'
                else if (element[1] != "" && element[1][0] != '-')
                {
                    return true;
                }

                //if there is a key
                if (element[1] == list[i])
                {
                    //checking for null in the 2 element
                    if (element[2] == "")
                    {
                        Console.WriteLine("\nwc: missing operand\r\nTry 'wc --help' for more information.\r\n");
                        return false;
                    }
                    ++check;
                }
            }
            //errors
            if (check == 0)
            {
                Console.WriteLine("\nwc: unknown option - " + element[1] + "\r\nTry 'wc --help' for more information.\n");
                return false;
            }
            return true;
        }
        public void begin()
        {
            if(str == "wc --help")
            {
                help cls = new help();
                cls.helping("wc");
                Console.WriteLine();
                return;
            }
               
            //finding element .txt
            for (int i = 0; i < element.Length; ++i)
            {
                if (element[i].Contains(".txt"))
                {
                    file_name = element[i];
                }
            }
            try
            {
                //read file
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + file_name))
                {
                    int check = 0;
                    string input = null;

                    //read strings
                    while ((input = (sr.ReadLine())) != null)
                    {
                        //add null elements
                        if (list_string.ElementAtOrDefault(check) == null)
                        {
                            Array.Resize(ref list_string, list_string.Length + 1);
                        }

                        //add string
                        list_string[check] = input;

                        ++check;
                    }
                }
            }
            catch (System.IO.DirectoryNotFoundException) { Console.WriteLine("\nwc: file not found\n"); return; }
            switch (element[1])
            {
                
                case "-l":
                    {
                        Console.Write(num_rows());
                        Console.Write("     ");
                        Console.Write(element[2]);
                        Console.WriteLine();
                        break;
                    }
                case "-w":
                    {
                        Console.Write(num_words());
                        Console.Write("     ");
                        Console.Write(element[2]);
                        Console.WriteLine();
                        break;
                    }
                case "-m":
                    {
                        Console.Write(num_bytes());
                        Console.Write("     ");
                        Console.Write(element[2]);
                        Console.WriteLine();
                        break;
                    }
                default:
                    {
                        Console.Write(num_rows());
                        Console.Write("     ");
                        Console.Write(num_words());
                        Console.Write("     ");
                        Console.Write(num_bytes());
                        Console.Write("     ");
                        Console.Write(element[1]);
                        Console.WriteLine();
                        break;
                    }
            }
        }

        public int num_rows()
        {
            //read file
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + file_name))
            {
                int check = 0;
                string input = null;

                //read strings
                while ((input = (sr.ReadLine())) != null)
                {
                    //add null elements
                    if (list_string.ElementAtOrDefault(check) == null)
                    {
                        Array.Resize(ref list_string, list_string.Length + 1);
                    }

                    //add string
                    list_string[check] = input;

                    ++check;
                }
            }
            return list_string.Length;
        }
        public int num_words()
        {
            //filling list_string
            num_rows();

            int check = 0;
            int check_words = 0;
            int count_words = 0;

            while (check < list_string.Length)
            {
                //get the words
                list_words = list_string[check].Split(' ');

                while (check_words < list_words.Length)
                {
                    //not null string
                    if (list_words[check_words] != "")
                    {
                        //counting words
                        count_words++;
                    }
                    
                    check_words++;
                }
                //clear
                check_words = 0;

                check++;
            }
            return count_words;
        }
        public int num_bytes()
        {
            //get bytes
            byte[] bytes = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\" + file_name);

            return bytes.Length;
        }
    }
}
