using System;

namespace GratulateBirthDay
{
    public interface IPeopleFinder
    {
        IPeopleRegister Registry { get; set; }

        string[] FindNamesFromBirthDayAt_OrNull(DateTime targetDate);
    }
}