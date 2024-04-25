using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay
{
    public class FamousPeopleFinder : IPeopleFinder
    {
        //private Dictionary<DateTime, string[]> _famousPeoplesBirthDays;
        public IPeopleRegister Registry { get; set; }
        public FamousPeopleFinder(IPeopleRegister famousPeoplesBirthDays)
        {
            Registry = famousPeoplesBirthDays;
        }

        public string[] FindNamesFromBirthDayAt_OrNull(DateTime targetDate)
        {

            return Registry.NameByBirthDate.Where(item =>
                item.Key == targetDate)
                .Select(item => item.Value)
                .FirstOrDefault();
        }

    }
}
