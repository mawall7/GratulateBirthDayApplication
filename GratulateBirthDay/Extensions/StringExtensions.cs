using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay.StringExtensions
{
    public static class StringExtensions
    {
        public static string GetFirstForeNameFromFullNames(this string fullname)
        {
            var forename = fullname.Split(" ")[0];
            return forename;
        }
    }
}
