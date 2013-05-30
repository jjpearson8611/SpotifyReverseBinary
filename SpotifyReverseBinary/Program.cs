using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyReverseBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int OrigNumber;

            bool KeepGoing = true;
            while (KeepGoing)
            {
                Console.WriteLine("Insert a decimal number");
                if (int.TryParse(Console.ReadLine(), out OrigNumber) == true)
                {
                    Console.WriteLine(ConvertToDecimal((ConvertToBinary(OrigNumber))));
                }
                else
                {
                    KeepGoing = false;
                }
            }

        }

        public static int ConvertToDecimal(string Number)
        {
            int Counter = 0;
            int Exponent = 0;
            while (Number.Length != 1)
            {
                Counter += (int.Parse(Number.Substring(Number.Length - 1, 1)) * (int)(Math.Pow(2, (double)Exponent)));
                Number = Number.Substring(0, Number.Length - 1);
                Exponent++;
            }

            Counter += int.Parse(Number) * (int)(Math.Pow(2, (double)Exponent));

            return Counter;
        }

        public static string ConvertToBinary(int Number)
        {
            string Returning = string.Empty;
            while (Number != 0 && Number != 1)
            {
                if ((Number % 2) == 1)
                {
                    Returning += "1";
                }
                else
                {
                    Returning += "0";
                }
                Number = Number / 2;
            }

            Returning = Returning + Number.ToString();

            return Returning;
        }
    }
}
