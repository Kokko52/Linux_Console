using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    //-С - выбирать процессы по имени команды;
    //-a - выбрать все процессы, кроме фоновых;
    //-p, (p) - выбрать процессы PID;

    //ps -C 'name'
    //ps -a
    //ps -p 'id'

    internal class ps
    {
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

            //number of keys found
            int check = 0;

            //list keys
            var list = new List<string>() { "--help", "-C", "-a", "-p" };

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //ps
                if (element[1] == "")
                {
                    return true;
                }

                //ps -a 'name'
                if (element[1] == "-a" && element[2] != "")
                {
                    Console.WriteLine("\nps: missing operand\r\nTry 'ps --help' for more information.\r\n");
                    return false;
                }
                //if there is a key
                if (element[1] == list[i])
                {
                    //finding the keys -C or -p
                    if (element[1] == "-C" || element[1] == "-p")
                    {
                        //checking for null in the 2 element
                        if (element[2] == "")
                        {
                            Console.WriteLine("\nps: missing operand\r\nTry 'ps --help' for more information.\r\n");
                            return false;
                        }
                        //if key = -p
                        if (element[1] == "-p")
                        {
                            //checking for a number
                            for (int j = 0; j < element[2].Length; j++)
                            {
                                if (!char.IsDigit(element[2][j]))
                                {
                                    Console.WriteLine("\nps: " + element[2] + ": invalid number of lines\n");
                                    return false;
                                }
                            }
                        }
                    }
                    ++check;
                }
            }
            //errors
            if (check == 0)
            {
                Console.WriteLine("\nps: unknown option - " + element[1] + "\r\nTry 'ps --help' for more information.\n");
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
                        cls.helping("ps");
                        Console.WriteLine();
                        break;
                    }
                case "-a":
                    {
                        Console.WriteLine("\tPID\t\tName \t\t\t\t\tTime");
                        foreach (Process process in Process.GetProcesses())
                        {
                            try
                            {
                                if (process.MainWindowHandle != IntPtr.Zero)
                                {
                                    Console.Write("\t");
                                    Console.Write(process.Id);
                                    Console.Write("\t\t");
                                    Console.Write(process.ProcessName);
                                    Console.Write("\t\t\t");
                                    Console.Write(process.StartTime.ToShortTimeString());
                                    Console.Write("\n");
                                }
                            }
                            catch (Exception) { Console.Write("\n"); }
                        }
                        break;
                    }
                case "-C":
                    {
                        Console.WriteLine("\tPID\t\tName \t\t\t\t\tTime");
                        foreach (Process process in Process.GetProcesses())
                        {
                            try
                            {
                                if (process.ProcessName == element[2])
                                {
                                    Console.Write("\t");
                                    Console.Write(process.Id);
                                    Console.Write("\t\t");
                                    Console.Write(process.ProcessName);
                                    Console.Write("\t\t\t");
                                    Console.Write(process.StartTime.ToShortTimeString());
                                    Console.Write("\n");
                                }
                            }
                            catch (Exception) { Console.Write("\n"); }
                        }
                        break;
                    }
                case "-p":
                    {
                        Console.WriteLine("\tPID\t\tName \t\t\t\t\tTime");
                        foreach (Process process in Process.GetProcesses())
                        {
                            try
                            {
                                if (process.Id == Convert.ToInt32(element[2]))
                                {
                                    Console.Write("\t");
                                    Console.Write(process.Id);
                                    Console.Write("\t\t");
                                    Console.Write(process.ProcessName);
                                    Console.Write("\t\t\t");
                                    Console.Write(process.StartTime.ToShortTimeString());
                                    Console.Write("\n");
                                }
                            }
                            catch (Exception) { Console.Write("\n"); }
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\tPID\t\tName \t\t\t\t\tTime");
                        foreach (Process process in Process.GetProcesses())
                        {
                            try
                            {
                                Console.Write("\t");
                                Console.Write(process.Id);
                                Console.Write("\t\t");
                                Console.Write(process.ProcessName);
                                Console.Write("\t\t\t");
                                Console.Write(process.StartTime.ToShortTimeString());
                                Console.Write("\n");
                            }
                            catch (Exception) { Console.Write("\n"); }
                        }
                        break;
                    }

            }

        }

    }
}
