using System;
using System.Collections.Generic;
using System.Text;

namespace _11.Threeuple
{
    public class Threeuple<ithem1, ithem2, ithem3>
    {
        public ithem1 FirstElement { get; set; }
        public ithem2 SecondElement { get; set; }
        public ithem3 ThirdElement { get; set; }

        public Threeuple(ithem1 firstElement, ithem2 secondElement, ithem3 thirdElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            ThirdElement = thirdElement;
        }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
