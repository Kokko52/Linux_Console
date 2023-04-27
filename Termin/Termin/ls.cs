using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class ls
    {
        public string key1, key2;
        public bool keys(string key1 = "", string key2 = "")
        {
            if (key1 != "--help" && key1 != "-a" && key1 != "-r" && key1 != "-X")
            {           
                Console.WriteLine("ls: unknown option -" + key1);
                return false;
            }
            else if(key2 == "") { }
            else if (key2 != "-a" && key2 != "-r" && key2 != "-X")
            {
                Console.WriteLine("ls: unknown option -" + key2);
                return false;
            }
            else  { }
            return true;
        }
        public void rec(string key1 = "", string key2 = "")
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            List<string> ls = new List<string>(files);
            if(key1 == "--help")
            {
                Console.WriteLine("help");
            }
            else if ((key1 == "-a" && key2 == "-r") || (key1 == "-r" && key2 == "-a"))
            {
                ls.Sort();
                ls.Reverse();
                foreach (string list in ls)
                {
                    Console.WriteLine(Path.GetFileName(list));
                }
                return;
            }
            else if((key1 == "-a" && key2 == "-X") || (key1 == "-X" && key2 == "-a"))
            {
                ls.Sort();
                foreach (string list in ls)
                {
                        Console.WriteLine(Path.GetFileName(list));
                }
                return;
            }
            else if (key1 == "-r" || key2 == "-r")
            {
                ls.Sort();
                ls.Reverse();
                foreach (string list in ls)
                {
                    if ((File.GetAttributes(list) & FileAttributes.Hidden) == FileAttributes.Hidden)
                    { }
                    else
                        Console.WriteLine(Path.GetFileName(list));
                }
                return;
            }
            else if(key1 == "-X" || key2 == "-X")
            {
                ls.Sort();
                foreach (string list in ls)
                {
                    if ((File.GetAttributes(list) & FileAttributes.Hidden) == FileAttributes.Hidden)
                    { }
                    else
                        Console.WriteLine(Path.GetFileName(list));
                }
                return;
            }
            else if (key1 == "-a" || key2 == "-a")
            {
                foreach (string list in ls)
                {
                    Console.WriteLine(Path.GetFileName(list));
                }
                return;
            }
            else
            {
                foreach (string list in ls)
                {
                    if ((File.GetAttributes(list) & FileAttributes.Hidden) == FileAttributes.Hidden)
                    { }
                    else
                        Console.WriteLine(Path.GetFileName(list));
                }
                return;
            }
        }
    }
}
