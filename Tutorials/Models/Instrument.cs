using System;
using System.Diagnostics;

namespace Tutorials
{
    //[DebuggerDisplay("ID = {Id}")]
    internal class Instrument
    {
        public uint _id;
        public uint Id { get { return _id; } set { _id = value; } }
        public string Issuer { get; set; }

        public virtual string WhatAmI()
        {
            return "Instrument";
        }

        [Obsolete("This method is done.")]
        public void DoNotUse()
        {
            Console.WriteLine("Obsolete");
        }

        [DebuggerStepThrough()]
        public void SkipMe()
        {
            Console.WriteLine("Skip me in the debugger.");
        }
    }
}