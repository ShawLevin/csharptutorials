using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            //BoxingAndUnboxing();   
            //Casting();

            //RefAndValueTypes();

            Console.WriteLine(HackerRankSherlock(66317)); //-1


        }

        private static string Nums(int threes, int fives)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < fives; i++)
            {
                sb.Append("5");
            }
            for (int i = fives; i < (fives+threes); i++)
            {
                sb.Append("3");
            }

            return sb.ToString();
        }


        private static string HackerRankSherlock(int digits)
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
                    return Nums(remainder, 3*i);
                }
            }
            if (digits % 5 == 0)
            {
                return Nums(digits, 0);
            }

            return "-1";
        }

        private static void HackerRankMilitaryTime()
        {
            String input = "07:05:45PM";

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
            Console.WriteLine(hours + ":" + minutes + ":"+ seconds);
        }

        private static void HackerRankStaircase()
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

        /// <summary>
        /// Objects are reference types and are passed by reference in C#.
        /// Objects will get modified inside method calls.
        /// Primitives such as ints are value types and a copy is passed to the method.
        /// Primitives will not get modified since a copy is made in the scope of the method.
        /// </summary>
        private static void RefAndValueTypes()
        {
            int x = 1;
            Instrument i = new Instrument() { Id = 1 };

            Console.WriteLine("Before..."); // 1 and 1
            Console.WriteLine(x); // 1
            Console.WriteLine(i.Id); // 1

            AlterParameters(x, i); // 2 and 2

            Console.WriteLine("After..."); // 1 and 2
            Console.WriteLine(x); // 1
            Console.WriteLine(i.Id); // 2
        }

        private static void AlterParameters(int x, Instrument i)
        {
            x++;
            i.Id++;

            Console.WriteLine("Inside...");
            Console.WriteLine(x);
            Console.WriteLine(i.Id);
        }

        private static void Structs()
        {
            /*
            CONSIDER defining a struct instead of a class if instances of the type are small and commonly short-lived or are commonly embedded in other objects.

            AVOID defining a struct unless the type has all of the following characteristics:
                It logically represents a single value, similar to primitive types(int, double, etc.).
                It has an instance size under 16 bytes.
                It is immutable.
                It will not have to be boxed frequently.

            https://msdn.microsoft.com/en-us/library/ms229017(v=vs.110).aspx
            */
        }

        private static void Casting()
        {
            Instrument i = new Instrument();
            Instrument e = new Equity();
            FixedIncome f = new FixedIncome();

            IList<Instrument> ins = new List<Instrument>() { i, e, f };

            foreach (Instrument x in ins)
            {
                Console.WriteLine(x.WhatAmI());

                if (x is Equity)
                {
                    Console.WriteLine("ShareClass: " + (x as Equity).ShareClass);
                }
                else
                {
                    Console.WriteLine("As: " + (x as Equity)); //This is null but not an exception.
                    //Console.WriteLine("Cast: " + (Equity)x); //This would throw exception.
                }
            }



        }

        /// <summary>
        /// Boxing of value types into reference types causes them to be put on the heap instead of the stack.
        /// Referencing a boxed object such as an int is now referencing the pointer instead of the direct value.
        /// This adds some functionality but comes at a cost of performance.
        /// </summary>
        private static void BoxingAndUnboxing()
        {
            int a = 123;
            object o = a; // The following line boxes i.
            a = (int)o;  // unboxing

            Console.WriteLine(String.Concat("shaw", a, true)); // i and true have to be boxed.

            List<int> boxfree = new List<int>() { 1, 2, 3, 4, 5 }; //no boxing.
            List<object> boxing = new List<object>() { 1, 2, 3, 4, 5 }; //these have to be boxed because they are value types going into a reference list.
            foreach (var i in boxfree)
            {
                Console.WriteLine(i); //No Boxing (method has overloads for primitive types).
            }
            for(int i = 0; i < boxing.Count; i++)
            {
                //Cast is required or compiler error.
                Console.WriteLine((int)boxing[i] * (int)boxing[i]); //Otherwise * is on two objects not two ints.
            }
        }
    }


    
}
