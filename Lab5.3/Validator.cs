using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5._3
{
    class Validator
    {
        public static bool CheckInt(string year)
        {

            if (Int32.TryParse(year, out int result) && result <= 9999 && result >= 1886)
            {
                return false;
            }
            Console.WriteLine("Sorry, that was not a valid option. Please try again");
            return true;
        }

        public static bool CheckDec(string price)
        {
            if (Decimal.TryParse(price, out decimal result))
            {
                return false;
            }
            Console.WriteLine("Sorry, that was not a valid option. Please try again");
            return true;
        }

        public static bool CheckDouble(string mileage)
        {
            if (Double.TryParse(mileage, out double result))
            {
                return false;
            }
            Console.WriteLine("Sorry, that was not a valid option. Please try again");
            return true;
        }


    }
}
