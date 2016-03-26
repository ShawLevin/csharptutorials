namespace Tutorials
{
    internal class Instrument
    {
        public uint _id;
        public uint Id { get { return _id; } set { _id = value; } }
        public string Issuer { get; set; }

        public virtual string WhatAmI()
        {
            return "Instrument";
        }

        public void CallInstanceMethod()
        {
            int x = 0;
        }

        public static void CallStaticMethod()
        {
            int x = 0;
        }
    }
}