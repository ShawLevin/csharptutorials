namespace Tutorials
{
    internal class Equity : Instrument
    {
        public decimal StrikePrice { get; set; }
        public string ShareClass { get; set; }

        public override string WhatAmI()
        {
            return "Equity";
        }
    }
}