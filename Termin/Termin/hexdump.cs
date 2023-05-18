using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin
{
    internal class hexdump
    {
        ////original string
        //public string str;

        //public bool err()
        //{
        //    return true;
        //}
        public void HEXDUMP(string filename)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + filename;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                int offset = 0;
                byte[] buffer = new byte[16];

                while (fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    Console.Write("{0:x6}  ", offset);

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        if (i == 8) Console.Write(" ");
                        if (i < buffer.Length) Console.Write("{0:x2} ", buffer[i]);
                        else Console.Write("   ");

                        if (i == buffer.Length - 1) Console.Write(" ");

                        if (buffer[i] < 32 || buffer[i] > 126)
                            buffer[i] = (byte)'.';
                    }

                    Console.WriteLine();
                    offset += buffer.Length;
                }
            }
        }

        public static void HEXDUMP_B(string filename)
        {
            string filePath = Directory.GetCurrentDirectory() + @"\" + filename;
            byte[] fileBytes = File.ReadAllBytes(filePath);
            int count = 0;
            foreach (byte b in fileBytes)
            {
                Console.Write(Convert.ToString(b, 8));
                count++;
                if (count == 16)
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
            if (count > 0) Console.WriteLine();
        }

        public static void HEXDUMP_С(string filename)
        {
            string filePath = Directory.GetCurrentDirectory() + @"\" + filename;
            const int bytesPerLine = 16;

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int totalBytesRead = 0;
                var buffer = new byte[bytesPerLine];
                while (true)
                {
                    int bytesRead = fs.Read(buffer, 0, bytesPerLine);

                    if (bytesRead == 0) break;

                    Console.Write("{0,8:x}: ", totalBytesRead);

                    for (int i = 0; i < bytesRead; i++)
                        Console.Write("{0:x2} ", buffer[i]);

                    for (int i = bytesRead; i < bytesPerLine; i++)
                        Console.Write(" ");

                    Console.WriteLine();
                    totalBytesRead += bytesRead;
                }
            }
        }

        public static void HEXDUMP_D(string filename)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + filename;
            byte[] fileBytes = File.ReadAllBytes(path);

            for (int i = 0; i < fileBytes.Length; i += 2)
            {
                if (i % 16 == 0)
                {
                    Console.Write("{0:x4}: ", i);
                }

                Console.Write("{0:d5} ", BitConverter.ToUInt16(fileBytes, i));

                if (i % 16 == 14 || i == fileBytes.Length - 2)
                {
                    Console.WriteLine();
                }
            }
        }

    }
}
