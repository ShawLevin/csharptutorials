using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Tutorials
{
    public static class Performance
    {
        public static void Loops()
        {
            int counter = 10000000;
            Console.WriteLine("Loop compares with counter: " + counter);
            List<Instrument> ins = new List<Instrument>();

            //Setup
            for (int i = 0; i < counter; i++)
            {
                ins.Add(new Instrument());
            }

            Stopwatch sw = new Stopwatch();

            //ForEach
            sw.Start();
            foreach (Instrument i in ins)
            {
                i.Id = 1;
            }
            sw.Stop();
            Console.WriteLine("ForEach: " + sw.ElapsedMilliseconds);

            //For Loop
            sw.Restart();
            for (int i = 0; i < ins.Count; i++)
            {
                ins[i].Id = 1;
            }
            sw.Stop();
            Console.WriteLine("For 0 to Counter: " + sw.ElapsedMilliseconds);

            //Loop counting down instead of up.
            sw.Restart();
            for (int i = ins.Count - 1; i != 0; i--)
            {
                ins[i].Id = 1;
            }
            sw.Stop();
            Console.WriteLine("For Counter to 0: " + sw.ElapsedMilliseconds);

            //Loop counting down instead of up.
            sw.Restart();
            for (int i = ins.Count - 1; i != 0; i--)
            {
                ins[i]._id = 1;
            }
            sw.Stop();
            Console.WriteLine("For Set Field: " + sw.ElapsedMilliseconds);
        }

        public static void Strings()
        {
            Stopwatch sw = new Stopwatch();
            String result = string.Empty;
            StringBuilder sb = new StringBuilder();
            int counter = 100000;

            Console.WriteLine("String manipulations with counter: " + counter);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                sb.Append(" ");
            }
            sw.Stop();
            Console.WriteLine("StringBuilder: " +sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                result += " ";
            }
            sw.Stop();
            Console.WriteLine("String: " + sw.ElapsedMilliseconds);


        }

        public static void IntTryParse()
        {
            Stopwatch sw = new Stopwatch();
            int result = 0;
            string parse = "Shaw";
            int counter = 100000;

            Console.WriteLine("Int parsing with counter: " + counter);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                Int32.TryParse(parse, out result);
            }
            sw.Stop();
            Console.WriteLine("TryParse: " + sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                try
                {
                    result = Int32.Parse(parse);
                }
                catch (Exception ex)
                {
                    result = 0;
                }
            }
            sw.Stop();
            Console.WriteLine("Parse: " + sw.ElapsedMilliseconds);
        }

        public static void DictionaryContainsKey()
        {
            Stopwatch sw = new Stopwatch();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int counter = 100000;

            Console.WriteLine("Dictionary key checking with counter: " + counter);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                if (dictionary.ContainsKey(counter))
                {
                    Console.WriteLine(dictionary[counter]);
                }
            }
            sw.Stop();
            Console.WriteLine("ContainsKey: " + sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                try
                {
                    Console.WriteLine(dictionary[counter]);
                }
                catch (Exception ex)
                {
                    
                }
            }
            sw.Stop();
            Console.WriteLine("TryCatch: " + sw.ElapsedMilliseconds);
        }

        public static void BoxedList()
        { }

        public static void ArrayVsList()
        {
            Stopwatch sw = new Stopwatch();
            int counter = 10000000;
            List<Instrument> list = new List<Instrument>();
            Instrument[] arr = new Instrument[counter];

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                list.Add(new Instrument());
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                arr[i] = new Instrument();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                list[i].Id = 1;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                arr[i].Id = 1;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static void InterfacedList()
        {
            Stopwatch sw = new Stopwatch();
            int counter = 10000000;
            List<Instrument> ins = new List<Instrument>();
            List<FixedIncome> fi = new List<FixedIncome>();
            List<Instrument> fins = new List<Instrument>();
            Console.WriteLine("Int parsing with counter: " + counter);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                ins.Add(new Instrument());
            }
            sw.Stop();
            Console.WriteLine("Interface: " + sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                fi.Add(new FixedIncome());
            }
            sw.Stop();
            Console.WriteLine("Conrete: " + sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < counter; i++)
            {
                fins.Add(new FixedIncome());
            }
            sw.Stop();
            Console.WriteLine("Mix: " + sw.ElapsedMilliseconds);
        }
    }
}
