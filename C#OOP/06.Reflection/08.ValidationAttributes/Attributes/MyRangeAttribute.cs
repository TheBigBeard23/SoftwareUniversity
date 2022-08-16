using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        private readonly bool inclusive;
        public MyRangeAttribute(int minValue, int maxValue, bool inclusive = true)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.inclusive = inclusive;
        }

        public override bool IsValid(object obj)
        {
            int value = (int)obj;

            if (inclusive)
            {
                return value >= minValue && value <= maxValue;
            }

            return value > minValue && value < maxValue;
        }
    }
}
