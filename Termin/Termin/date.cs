using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    class date
    {
        public string str;
        /*
         * date %Y
         * date %d
         * date %m    
         * */
        public bool err()
        {
            // getting string elements
            string[] element = new string[] { };
            element = str.Split(' ');

            //list keys
            var list = new List<string>() { "--help", "%Y", "%D", "%m" };

            //add null elements
            #region
            if (element.ElementAtOrDefault(1) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }
            if (element.ElementAtOrDefault(2) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }
            if (element.ElementAtOrDefault(3) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }
            #endregion

            int check_key1 = 0;
            int check_key2 = 0;

            if (str == "date --help")
            {
                return true;
            }
            
            //checking for keys
            if (element[1] == "" || element[1][0] == '+')
            {
                for (int i = 0; i < list.Count; i++)
                {
                    // date
                    if (element[1] == "")
                    {
                        check_key1++;
                        check_key2++;
                        break;
                    }
                    
                    if (str.Contains("%Y"))
                    {
                        check_key1++;
                        check_key2++;
                        break;
                    }
                    if (str.Contains("%d"))
                    {
                        check_key1++;
                        check_key2++;
                        break;
                    }
                    if (str.Contains("%m"))
                    {
                        check_key1++;
                        check_key2++;
                        break;
                    }               
                }
            }

            else
            {
                Console.WriteLine("date: invalid date \'" + element[1] + "\'");
                return false;
            }
          
            return true;
        }
        public void begin()
        {
            // getting string elements
            string[] element = new string[] { };
            element = str.Split('%');

            // getting string elements
            string[] date = new string[] { };
            date = str.Split(' ');
            if(str == "date --help")
            {
                help cls = new help();
                cls.helping("date");
                Console.WriteLine();
                return;
            }
            if (date.Length == 1)
            {
                Console.WriteLine(DateTime.Now);
            }
            else
            {
                for (int i = 1; i < element.Length; i++)
                {
                    if (element[i].Contains("Y"))
                    {
                        Console.WriteLine(DateTime.Now.Year);
                    }
                    if (element[i].Contains("d"))
                    {
                        Console.WriteLine(DateTime.Now.Day);
                    }
                    if (element[i].Contains("m"))
                    {
                        Console.WriteLine(DateTime.Now.Month);
                    }
                }
            }
            }
        }
}
