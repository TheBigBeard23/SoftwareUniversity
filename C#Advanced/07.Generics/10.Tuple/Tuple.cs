
using System;
using System.Collections.Generic;
using System.Text;

namespace _10.Tuple
{
    public class Tuple<ithem1, ithem2>
    {
        public ithem1 FirstIthem { get; set; }
        public ithem2 SecondIthem { get; set; }

        public Tuple(ithem1 firstIthem,ithem2 secondIthem)
        {
            FirstIthem = firstIthem;
            SecondIthem = secondIthem;
        }

        public override string ToString()
        {
            return $"{FirstIthem} -> {SecondIthem}";
        }
    }
}
