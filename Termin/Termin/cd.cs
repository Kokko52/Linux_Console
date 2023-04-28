using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class cd
    {
        public string keys(string key1 = "", string path = "")
        {
            string Path = "";
            try
            {
                Directory.SetCurrentDirectory(key1);
                Path = Directory.GetCurrentDirectory();
                var info = new DirectoryInfo(Path);
            }
            catch
            {
                Console.WriteLine("No such directory");
                Path = path;
            }
            return Path;
        }
    }
}
