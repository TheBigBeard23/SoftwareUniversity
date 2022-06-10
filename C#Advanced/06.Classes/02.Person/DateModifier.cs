using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int GetDays(string firstDate,string secondDate)
        {
            var first = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.GetCultureInfo("ja-JP"));
            var second = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.GetCultureInfo("ja-JP"));

            return (second.Date - first.Date).Days;
        }
    }
}
