using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Termin
{
    class help
    {
        public void helping(string command)
        {
            try
            {
                string path_man = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "man");

                using (StreamReader sr = new StreamReader(path_man + "\\" + command + ".txt"))
                {
                    string line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception) { Console.WriteLine("\nman: command not found"); }
        }
    }
}
