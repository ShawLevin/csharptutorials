using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    class Equity : Instrument
    {
        public decimal StrikePrice { get; set; }
        public string ShareClass { get; set; }

        public override string WhatAmI()
        {
            return "Equity";
        }
    }
}
