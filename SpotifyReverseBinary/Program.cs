//
// This program takes a number and converts it to binary then converts the backwards binary back to decimal
//
//
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
            //holds the typed in number
            int OrigNumber;

            //just a simple loop to keep testing until you dont enter a whole number
            bool KeepGoing = true;

            //KEEP GOING!
            while (KeepGoing)
            {
                //get a whole numbered int from the user
                Console.WriteLine("Insert a whole number");
                if (int.TryParse(Console.ReadLine(), out OrigNumber) == true)
                {
                    //write out the new decimal number
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
            //counts the total
            int Counter = 0;

            //counts the exponent for 2
            int Exponent = 0;

            //while there are still numbers left
            while (Number.Length != 1)
            {
                //increase counter by the right most number times 2 ^ exponent
                Counter += (int.Parse(Number.Substring(Number.Length - 1, 1)) * (int)(Math.Pow(2, (double)Exponent)));
                
                //Shift right logical if you will
                Number = Number.Substring(0, Number.Length - 1);
                
                //increase the exponent number
                Exponent++;
            }

            //increase the counter for the last number
            Counter += int.Parse(Number) * (int)(Math.Pow(2, (double)Exponent));

            //return the final decimal number
            return Counter;
        }

        public static string ConvertToBinary(int Number)
        {
            //string to hold the returned binary number
            string Returning = string.Empty;

            //keep going until there is only one 0 or 1 left in the number
            while (Number != 0 && Number != 1)
            {
                //determine if the binary number is 0 or 1
                if ((Number % 2) == 1)
                {
                    Returning += "1";
                }
                else
                {
                    Returning += "0";
                }

                //divide the number by 2 and do it again
                Number = Number / 2;
            }

            //add the last 0 or 1 to the number
            Returning = Returning + Number.ToString();

            //return the binary number
            return Returning;
        }
    }
}
