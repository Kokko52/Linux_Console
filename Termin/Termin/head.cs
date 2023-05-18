using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class head
    {
        // -n 'int' 'name'- count strings
        // -v -name file
        // -q == head

        public string str;
        public bool err()
        {
            // getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //list keys
            var list = new List<string>() { "--help", "-n", "-v", "-q" };

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
            for (int i = 0; i < list.Count; i++)
            {
                //head
                if (element[1] == "")
                {
                    Console.WriteLine("\nrm: missing operand\r\nTry 'rm --help' for more information.\r\n");
                    return false;
                }
                //head 'name'
                if (element[1] != "" && element[1][0] != '-')
                {

                }
                //head -n 'int' 'name'
                if (element[1] == "-n")
                {
                    for (int j = 0; j < element[2].Length; ++j)
                    {
                        try
                        {
                            if (!char.IsDigit(element[2][j]))
                            {
                                Console.WriteLine("\nhead: " + element[2] + ": invalid number of lines\n");
                                return false;
                            }
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            Console.WriteLine("\nhead: option requires an argument -- \'n\'\n" +
                                "Try \'head --help\' for more information\n");
                            return false;
                        }
                    }
                    if (element[3] == "")
                    {
                        Console.WriteLine("\nhead: file not found");
                        return false;
                    }
                }
                else if (element[1] == "-v")
                {
                    if (element[2] == "")
                    {
                        Console.WriteLine("\nhead: file not found");
                        return false;
                    }

                }
                else if (element[1] == "-q")
                {
                    if (element[2] == "")
                    {
                        Console.WriteLine("\nhead: file not found");
                        return false;
                    }
                }
            }
            return true;
        }
        public void begin()
        {
            // getting string elements
            string[] element = new string[] { };
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

            try
            {
                if (str == "head --help")
                {
                    help cls = new help();
                    cls.helping("head");
                    Console.WriteLine();
                    return;
                }
                if (element[1] == "-n")
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + element[3]))
                        {
                            string input = null;
                            int check = 0;
                            while ((input = sr.ReadLine()) != null && check < Convert.ToInt32(element[2]))
                            {
                                string Str = Convert.ToString(input);
                                Console.WriteLine(Str);
                                ++check;
                            }
                        }
                    }
                    catch (Exception e) { Console.WriteLine("can't find the file or is it a directory"); }
                }
                else if (element[1] == "-v")
                {
                    try
                    {
                        Console.WriteLine("==> " + element[2] + " <==");
                        using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + element[2]))
                        {
                            string input = null;
                            int check = 0;
                            while ((input = sr.ReadLine()) != null && check < 10)
                            {
                                string Str = Convert.ToString(input);
                                Console.WriteLine(Str);
                                ++check;
                            }

                        }
                    }
                    catch (Exception e) { Console.WriteLine("can't find the file or is it a directory"); }
                }
                else if (element[1] == "-q")
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + element[2]))
                        {
                            int check = 0;
                            string input = null;
                            while ((input = sr.ReadLine()) != null && check < 10)
                            {
                                string Str = Convert.ToString(input);
                                Console.WriteLine(Str);
                                ++check;
                            }
                        }
                    }
                    catch (Exception e) { Console.WriteLine("can't find the file or is it a directory"); }
                }
                else
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + element[1]))
                        {
                            string input = null;
                            int check = 0;
                            while ((input = sr.ReadLine()) != null && check < 10)
                            {
                                string Str = Convert.ToString(input);
                                Console.WriteLine(Str);
                                ++check;
                            }
                        }
                    }
                    catch (Exception e) { Console.WriteLine("can't find the file or is it a directory"); }

                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("\nhead: file not found\n");
            }
        }
    }
}
