using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class rmdir
    {
        public string keys(string name)
        {
            Directory.Delete(name);
            return "";
        }
    }
}
