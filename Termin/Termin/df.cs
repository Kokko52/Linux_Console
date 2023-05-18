using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    //-k 
    //-h
    //-H - выводить все размеры в гигабайтах;
    internal class df
    {
        //current path
        public string str;
        //list elements
        public static string[] element = new string[] { };
        public bool err()
        {
            // getting string elements
            element = str.Split(' ');

            //add null elements
            if (element.ElementAtOrDefault(1) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }
            //number of keys found
            int check = 0;

            //list keys
            var list = new List<string>() { "--help", "-k", "-h", "-H" };

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //df
                if (element[1] == "")
                {
                    return true;
                }
                //if there is a key
                if (element[1] == list[i])
                {
                    check++;
                }
            }
            //errors
            if (check == 0)
            {
                Console.WriteLine("\ndf: unknown option - " + element[1] + "\r\nTry 'df --help' for more information.\n");
                return false;
            }
            return true;
        }
        public void begin()
        {
            switch (element[1])
            {
                case "--help":
                    {
                        help cls = new help();
                        cls.helping("df");
                        Console.WriteLine();
                        break;
                    }
                case "-k":
                    {
                        func(1000, "K\t");
                        break;  
                    }
                case "-H":
                    {
                        func(1073741824, "G\t\t");
                        break;
                    }
                case "-h":
                    {
                        func(1048576, "M\t\t");
                        break;
                    }
                default:
                    {
                        func(1, "\t");
                        break;
                    }
            }
        }
        public void func(int del, string unit)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            Console.WriteLine("FileSystem\t1K-blocks\tUsed\t\tAvailable\tUse%\tMounted on");
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                { 
                    Console.Write(d.DriveType + "\t\t");
                    Console.Write(d.TotalSize / del + unit);
                    Console.Write((d.TotalSize - d.AvailableFreeSpace )/ del + unit);
                    Console.Write(Math.Round((decimal)d.AvailableFreeSpace / del) + unit);
                    Console.Write(Math.Round(((decimal)d.TotalSize - (decimal)d.AvailableFreeSpace) / (decimal)d.TotalSize * 100)+ "%\t");
                    Console.Write(d.Name);
                    Console.WriteLine();
                }
            }
        }    
    }
    
}
