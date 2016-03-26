using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    class HackerRank
    {
        private static string Nums(int threes, int fives)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < fives; i++)
            {
                sb.Append("5");
            }
            for (int i = fives; i < (fives + threes); i++)
            {
                sb.Append("3");
            }

            return sb.ToString();
        }

        internal static string Sherlock(int digits)
        {
            //Console.Write(digits + ": ");
            if (digits < 3)
            {
                return "-1";
            }
            if (digits % 3 == 0)
            {
                return Nums(0, digits);
            }

            int factor = digits / 3;
            int remainder = 0;

            for (int i = factor; i > 0; i--)
            {
                remainder = digits - (3 * i);
                if (remainder % 5 == 0)
                {
                    return Nums(remainder, 3 * i);
                }
            }
            if (digits % 5 == 0)
            {
                return Nums(digits, 0);
            }

            return "-1";
        }

        internal static void MilitaryTime(string input)
        {
            DateTime d = DateTime.Parse(input);

            //19:05:45
            String hours = "", minutes = "", seconds = "";
            if (d.Hour > 9)
            {
                hours = d.Hour.ToString();
            }
            else
            {
                hours = "0" + d.Hour.ToString();
            }

            if (d.Minute > 9)
            {
                minutes = d.Minute.ToString();
            }
            else
            {
                minutes = "0" + d.Minute.ToString();
            }

            if (d.Second > 9)
            {
                seconds = d.Second.ToString();
            }
            else
            {
                seconds = "0" + d.Second.ToString();
            }
            Console.WriteLine(hours + ":" + minutes + ":" + seconds);
        }

        internal static void Staircase()
        {
            int n = 5;
            char[] list = new char[n];

            for (int i = 0; i < n; i++)
            {
                list[i] = ' ';
            }

            for (int i = n - 1; i >= 0; i--)
            {
                list[i] = '#';
                for (int x = 0; x < list.Length; x++)
                {
                    Console.Write(list[x]);
                }
                Console.WriteLine("");
            }
        }
    }
}
