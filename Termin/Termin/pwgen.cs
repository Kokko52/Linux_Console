using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Data;

namespace Termin
{
    internal class pwgen
    {

        /*
         * -c , --capitalize	Включить в пароль хотя бы одну прописную (большую) букву
         * -A, --no-capitalize	Не использовать прописные (большие) буквы при создании пароля.
         * -n, --numerals	Включить в пароль хотя бы одну цифру
         * -0, --no-numerals	Не использовать цифры при создании пароля
         * -y, --symbols	Включить в пароль хотя бы один специальный символ
         * Пример создания шести паролей с длиной в 10 символов:pwgen 10 6
         */

        //original string
        public string str;
        //list elements
        public static string[] element = new string[] { };
        //number or letter
        public Random check = new Random();
        //number
        public Random rnd_number = new Random();
        //letter
        public Random rnd_letter = new Random();
        //symbol
        public Random rnd_symbol_check = new Random();
        //pwgen -A
        public bool key_A = false;
        //pwgen -0
        public bool key_0 = false;

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
            if (element.ElementAtOrDefault(2) == null)
            {
                Array.Resize(ref element, element.Length + 1);
                element[element.Length - 1] = "";
            }

            //number of keys found
            int check = 0;

            //list keys
            var list = new List<string>() { "--help", "-A", "-0", "-y" };

            //finding keys
            for (int i = 0; i < list.Count; ++i)
            {
                //pwgen
                if (element[1] == "")
                {
                    return true;
                }
                /*
                //pwgen 'int'
                if (element[1] != "" && element[1][0] != '-')
                {
                    //checking for a number 1 element
                    for (int j = 0; j < element[1].Length; j++)
                    {
                        if (!char.IsDigit(element[1][j]))
                        {
                            Console.WriteLine("\npwgen: " + element[1] + ": invalid number of lines\n");
                            return false;
                        }
                        ++check;
                    }
                }*/

                //if there is a key
                if (element[1] == list[i])
                {
                    check++;
                }

            }

            //errors
            if (check == 0)
            {
                Console.WriteLine("\npwgen: unknown option - " + element[1] + "\r\nTry 'pwgen --help' for more information.\n");
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
                        cls.helping("pwgen");
                        Console.WriteLine();
                        break;
                    }
                case "-A":
                    {
                        key_A = true;
                        GenerationPassword(1, 3);
                        key_A = false;
                        break;
                    }
                case "-0":
                    {
                        key_0 = true;
                        GenerationPassword(2, 3);
                        key_0 = false;
                        break;
                    }
                case "-y":
                    {
                        GenerationPassword(1, 4);

                        break;
                    }
                default:
                    {
                        GenerationPassword(1, 3);
                        break;
                    }
            }
        }

        public void GenerationPassword(int min, int max)
        {
            //string password
            string password = "";

            //count password
            for (int i = 0; i < 120; i++)
            {
            m_new:
                //count of symbol in the password
                for (int j = 0; j < 8; ++j)
                {
                    //check number or letter or symbol
                    int ch = check.Next(min, max);

                    //number
                    if (ch == 1)
                    {
                        password += GenerationNumber();
                    }
                    //symbol
                    else if (ch == 3)
                    {
                        password += GenerationSymbol();
                    }
                    //letter
                    else
                    {
                        password += GenerationLetter();
                    }
                }
                //if symbol
                if (max == 4)
                {
                    //if contains symbol in the password
                    #region if_Constain_symbol
                    if (password.Contains('!') || password.Contains('@') || password.Contains('#') || password.Contains('$') || password.Contains('%')
                                       || password.Contains('^') || password.Contains('&') || password.Contains('*') || password.Contains('+') || password.Contains('=')
                                       || password.Contains('-') || password.Contains('>') || password.Contains('<') || password.Contains('?') || password.Contains('_')
                                       || password.Contains('-')) { }
                    #endregion
                    // if NO constains symbol in the password
                    else
                    {
                        //clear password
                        password = "";
                        //go to the new password
                        goto m_new;
                    }
                }
                // 5 columns
                if (i % 6 != 0)
                {
                    Console.Write(password + " ");
                }
                else
                {
                    Console.WriteLine();
                }
                //

                //clear password
                password = "";
            }
            //new line
            Console.WriteLine("\n");
        }

        public int GenerationNumber()
        {
            int number = 0;
            //random number
            number = rnd_number.Next(0, 10);
            return number;
        }
        public char GenerationLetter()
        {
            char letter;
            string rnd_num = "";

        m_new:
            //random letter
            rnd_num += rnd_letter.Next(65, 122);
            //if containt symbols
            if (rnd_num == "91" || rnd_num == "92" || rnd_num == "93" || rnd_num == "94" || rnd_num == "95" || rnd_num == "96")
            {
                rnd_num = "";
                //go to new letter
                goto m_new;
            }
            else
            {
                //pwgen -A
                if (key_A)
                {
                    //if containt uppercase
                    if (Convert.ToInt32(rnd_num) > 64 && Convert.ToInt32(rnd_num) < 91)
                    {
                        rnd_num = "";
                        //go to new letter
                        goto m_new;
                    }
                    else
                    {
                        letter = Convert.ToChar(Convert.ToInt32(rnd_num));
                    }
                }
                else
                {
                    letter = Convert.ToChar(Convert.ToInt32(rnd_num));
                }

            }
            return letter;
        }
        public char GenerationSymbol()
        {
            //list symbols
            string symbols = "!@#$%^&*+=-><?_-";
            int check = rnd_symbol_check.Next(0, symbols.Length - 1);

            return symbols[check];
        }
    }
}
