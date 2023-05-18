using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class pwd
    {
        public string str;
        public void begin()
        {
            try
            {
                if (str == "pwd --help")
                {
                    help cls = new help();
                    cls.helping("pwd");
                    Console.WriteLine();
                    return;
                }
                Console.WriteLine(Environment.CurrentDirectory);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
