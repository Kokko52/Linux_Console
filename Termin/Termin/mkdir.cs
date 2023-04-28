using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class mkdir
    {
        public string keys(string name_dir, string path)
        {
            string create_directory = path +"\\" + name_dir;
          string[] files = Directory.GetDirectories(path);
          for (int i = 0; i < files.Length; i++)
          {
              string f = Path.GetFileName(files[i]);
              if( f== name_dir)
              {

                  Console.WriteLine("mkdir: cannot create directory \'" + name_dir + "\': File exists");
                  break;
              }
          }
              Directory.CreateDirectory(create_directory);
            return "";
        }
    }
}
