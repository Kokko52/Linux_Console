using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class man
    {
        public string str;
        public string err()
        {
            if(str == "man")
            {
                Console.WriteLine("command not found");
                return "command not found";
            }
            return "";
        }
        public bool help()
        {
            if (str == "")
            {
                return false;
            }
            else
            {
                return true;
            }
            return true;
        }
        public bool key_1()
        {
            if (str == "")
            {
                return false;
            }
            return true;
        }
        public bool key_2()
        {
            if (str == "")
            {
                return false;
            }
            return true;
        }
        public bool key_3()
        {
            if (str == "")
            {
                return false;
            }
            return true;
        }
        public string print(bool k1, bool k2, bool k3, bool k4)
        {
            return "";
        }
    }
}
