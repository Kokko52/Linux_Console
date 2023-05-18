using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Termin
{
    internal class kill
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
            var list = new List<string>() { "--help", "-l", "-v" };

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //kill
                if (element[1] == "")
                {
                    Console.WriteLine("\nkill: missing operand\r\nTry 'kill --help' for more information.\r\n");
                    return false;
                }
                if (element[1] != "" && element[1][0] != '-')
                {
                    //checking for a number
                    for (int j = 0; j < element[1].Length; j++)
                    {
                        if (!char.IsDigit(element[1][j]))
                        {
                            Console.WriteLine("\ntail: " + element[2] + ": invalid number of lines\n");
                            return false;
                        }
                    }
                    return true;
                }
                //if there is a key
                if (element[1] == list[i])
                {
                    //kill -v 'int'
                    if (element[1] == "-v")
                    {
                        //checking for a number
                        for (int j = 0; j < element[2].Length; j++)
                        {
                            if (!char.IsDigit(element[2][j]))
                            {
                                Console.WriteLine("\nkill: " + element[2] + ": invalid number of lines\n");
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
                Console.WriteLine("\nkill: unknown option - " + element[1] + "\r\nTry 'kill --help' for more information.\n");
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
                        cls.helping("kill");
                        Console.WriteLine();
                        break;
                    }
                case "-l":
                    {
                        Console.WriteLine("1) SIGHUP 2) SIGINT 3) SIGQUIT 4) SIGILL 5) SIGTRAP" +
                                          "6) SIGABRT 7) SIGBUS 8) SIGFPE 9) SIGKILL 10) SIGUSR1" +
                                          "11) SIGSEGV 12) SIGUSR2 13) SIGPIPE 14) SIGALRM 15) SIGTERM" +
                                          "16) SIGSTKFLT 17) SIGCHLD 18) SIGCONT 19) SIGSTOP 20) SIGTSTP" +
                                          "21) SIGTTIN 22) SIGTTOU 23) SIGURG 24) SIGXCPU 25) SIGXFSZ" +
                                          "26) SIGVTALRM 27) SIGPROF 28) SIGWINCH 29) SIGIO 30) SIGPWR" +
                                          "31) SIGSYS 34) SIGRTMIN 35) SIGRTMIN+1 36) SIGRTMIN+2 37) SIGRTMIN+3" +
                                          "38) SIGRTMIN+4 39) SIGRTMIN+5 40) SIGRTMIN+6 41) SIGRTMIN+7 42) SIGRTMIN+8" +
                                          "43) SIGRTMIN+9 44) SIGRTMIN+10 45) SIGRTMIN+11 46) SIGRTMIN+12 47) SIGRTMIN+13" +
                                          "48) SIGRTMIN+14 49) SIGRTMIN+15 50) SIGRTMAX-14 51) SIGRTMAX-13 52) SIGRTMAX-12" +
                                          "53) SIGRTMAX-11 54) SIGRTMAX-10 55) SIGRTMAX-9 56) SIGRTMAX-8 57) SIGRTMAX-7" +
                                          "58) SIGRTMAX-6 59) SIGRTMAX-5 60) SIGRTMAX-4 61) SIGRTMAX-3 62) SIGRTMAX-2" +
                                          "63) SIGRTMAX-1 64) SIGRTMAX");
                        break;
                    }
                case "-v":
                    {
                        Process[] process = Process.GetProcesses();
                        foreach (Process prs in process)
                        {
                            if (prs.Id == Convert.ToInt32(element[2]))
                            {
                                Console.WriteLine(prs.Id + " " + prs.ProcessName + " - kill");
                                prs.Kill();
                            }
                        }
                        break;
                    }
                default:
                    {
                        Process[] process = Process.GetProcesses();
                        foreach (Process prs in process)
                        {
                            if (prs.Id == Convert.ToInt32(element[1]))
                            {
                                prs.Kill();
                            }
                        }
                        break;
                    }
            }
        }
    }
}
