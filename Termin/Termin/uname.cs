using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class uname
    {
        /*
        * uname - OS
        * uname -n
        * uname -p
        * uname -
        */

        public string str;
        public bool err()
        { 
            /*
           Console.WriteLine(Environment.OSVersion.VersionString); // -v
            Console.WriteLine(Environment.Is64BitOperatingSystem ? "x64" : "x32");//-p
            Console.WriteLine(Environment.UserName); // -n

            // -m
            string Host = System.Net.Dns.GetHostName();
            string IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();
            Console.WriteLine(IP);
            //*/
            // getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //add null elements
            if (element.ElementAtOrDefault(1) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }

            //list keys
            var list = new List<string>() { "--help", "-n", "-p", "-v" };
            int check = 0;
            if (element[1] == "")
            {
                return true;
            }
            //finding keys
            for(int i = 0; i < list.Count; ++i)
            {
                if (element[1] == list[i])
                {
                    ++check;
                }
            }
            if(check == 0)
            {
                Console.WriteLine("\nuname: unknown option -- " + element[1] +"\r\nTry 'uname --help' for more information.\n");
                return false;
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

            switch (element[1])
            {
                case "--help":
                    {
                        help cls = new help();
                        cls.helping("uname");
                        Console.WriteLine();
                        break;
                    }
                case "-p":
                    {
                        Console.WriteLine(Environment.Is64BitOperatingSystem ? "\nx64\n" : "\nx32\n");
                        break;
                    }
                case "-v":
                    {
                        Console.WriteLine("\n" + Environment.OSVersion.VersionString + "\n");
                        break;
                    }
                case "-n":
                    {
                        string Host = System.Net.Dns.GetHostName();
                        string IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();
                        Console.WriteLine("\n" + IP + "\n");
                        break;
                    }
                default:
                    {
                        string os = Environment.OSVersion.VersionString;
                        string kernel = os.Split(' ')[1];
                        Console.WriteLine("\n" + kernel + "\n");
                        break;
                    }
            }
        }
    }
}
