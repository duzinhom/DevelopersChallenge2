using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NiboChallenge.Helpers
{
    public class DateFormatHelper
    {
        public DateTime FormatDate(string date)
        {
            date = date.Substring(0, 8);
            date = (date.Substring(0, 4) + '-' + date.Substring(4, 2) + '-' + date.Substring(6, 2));
            return DateTime.Parse(date);
        }
    }
}
