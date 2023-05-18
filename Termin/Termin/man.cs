using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Termin
{
    class man
    {
        //original string
        public string str;
        //list elements
        public static string[] element = new string[] { };

        public bool err()
        {
            //getting string elements
            element = str.Split(' ');

            //add null elements
            if (element.ElementAtOrDefault(1) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }
            if (str == "man --help")
            {
                element[1] = "man";
                return true;
            }
            if (element[1] == "")
            {
                Console.WriteLine("\nman: missing operand\r\nTry 'man --help' for more information.\r\n");
                return false;
            }

            return true;
        }
        public void begin()
        {
            try
            {
                help cls = new help();
                cls.helping(element[1]);
                Console.WriteLine();
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
