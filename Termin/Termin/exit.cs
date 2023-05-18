using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class exit
    {
        public string str;
        public void begin()
        {
            try
            {
                if (str == "exit --help")
                {
                    help cls = new help();
                    cls.helping("exit");
                    Console.WriteLine();
                    return;
                }
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
