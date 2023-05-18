using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class tail
    {
        //original string
        public string str;
        //file .txt
        public string file_name;
        //list elements
        public static string[] element = new string[] { };
        //list strings
        public string[] list_string = new string[] { };
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
            var list = new List<string>() { "--help", "-v", "-n", "-p"};

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //tail
                if (element[1] == "")
                {
                    Console.WriteLine("\ntail: missing operand\r\nTry 'tail --help' for more information.\r\n");
                    return false;
                }
                if(str == "tail --help")
                {
                    return true;
                }
                //tail 'name'
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
                        Console.WriteLine("\ntail: missing operand\r\nTry 'mkdir --help' for more information.\r\n");
                        return false;
                    }

                    //finding the keys -n
                    if (element[1] == "-n")
                    {
                        //checking for null in the 3 element
                        if (element[3] == "")
                        {
                            Console.WriteLine("\ntail: missing operand\r\nTry 'mkdir --help' for more information.\r\n");
                            return false;
                        }
                        //checking for a number
                        for (int j = 0; j < element[2].Length; j++)
                        {
                            if (!char.IsDigit(element[2][j]))
                            {
                                Console.WriteLine("\ntail: " + element[2] + ": invalid number of lines\n");
                                return false;
                            }
                        }
                    }

                    ++check;
                }
            }

            //errors
            if (check == 0)
            {
                Console.WriteLine("\ntail: unknown option - " + element[1] + "\r\nTry 'tail --help' for more information.\n");
                return false;
            }

            return true;
        }
        public void begin()
        {
            try
            {
            if(str == "tail --help")
            {
                help cls = new help();
                cls.helping("tail");
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

            //read file
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + file_name))
            {          
                int check = 0;
                string input = null;

                //read strings
                while ((input =(sr.ReadLine())) != null)
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

            Console.WriteLine("\t");

            switch (element[1])
            {

                case "-v":
                    {
                        //writing
                        Console.WriteLine("==> " + file_name + " <==");
                        for(int i = 10; i != 0; --i)
                        {
                            Console.WriteLine(list_string[list_string.Length -i]);
                        }
                        //

                        break;
                    }
                case "-p":
                    {
                        //writing
                        for (int i = 10; i != 0; --i)
                        {
                            Console.WriteLine(list_string[list_string.Length - i]);
                        }

                        break;
                    }
                case "-n":
                    {
                        int count_input_str = 0;

                        //checking for = number of string
                        if (Convert.ToInt32(element[2]) > list_string.Length)
                        {
                            count_input_str = list_string.Length;
                        }
                        else { count_input_str = Convert.ToInt32(element[2]); }
                        //

                        //writing
                        for (int i = count_input_str; i != 0 ; --i)
                        {
                            Console.WriteLine(list_string[list_string.Length - i]);
                        }

                        break;
                    }
                default:
                    {
                        //writing
                        for (int i = 10; i != 0; --i)
                        {
                            Console.WriteLine(list_string[list_string.Length - i]);
                        }

                        break;
                    }
            }

            Console.WriteLine("\t");
            }
            catch (Exception e) { Console.WriteLine("can't find file"); }
        }
    }
}
