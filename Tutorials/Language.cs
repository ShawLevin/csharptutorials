using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    class Language
    {
        private static void Structs()
        { }

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

            List<int> boxfree = new List<int>() { 1, 2, 3, 4, 5 };
            List<object> boxing = new List<object>() { 1, 2, 3, 4, 5 }; //these have to be boxed.
            foreach (var i in boxfree)
            {
                Console.WriteLine(i); //No Boxing.
            }
            for (int i = 0; i < boxing.Count; i++)
            {
                //Cast is required or compiler error.
                Console.WriteLine((int)boxing[i] * (int)boxing[i]); //Otherwise * is on two objects not two ints.
            }
        }
    }
}
