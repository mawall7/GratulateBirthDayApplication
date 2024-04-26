using GratulateBirthDay.StringExtensions;
using System;
using System.Collections.Generic;

namespace GratulateBirthDay
{
    public class BirthDayApplication
    {
        private IUserInteractor _ui;
        private IPeopleFinder _peopleFinder;

        public BirthDayApplication(IPeopleFinder peopleFinder, IUserInteractor consoleui)
        {
            _ui = consoleui;
            _peopleFinder = peopleFinder;
        }

        public void Run()
        {
            
             var searchDate = GetSampleDate();
       
            _ui.Read("Find out a birthday of a famous person. (Press key)");
          
            _ui.Read($"Any famous who has birthday on " +
                $"{searchDate.Day}/{searchDate.Month} {searchDate.Year} ?." +
                $" (Press key)");
              
            var namesWithBirthday = _peopleFinder
                .FindNamesFromBirthDayAt_OrNull(searchDate);
            
            if (namesWithBirthday == null)
            {
                _ui.ShowMessage("Nope. No one known has birthday at this particular date. ");
            }
            else 
            {
                string foreName = default;
            
                foreach (var name in namesWithBirthday)
                {
                    _ui.ShowMessage(((Person)name).ToString());
                    foreName = name.GetFirstForeNameFromFullNames();
                }

                _ui.ShowMessage("Happy birthday " + foreName + "!. And all of you!.");
            }
            _ui.Read();
        }

     
        public DateTime GetSampleDate() => DateTime.Parse(Resource1.SampleData);

       
    }
}