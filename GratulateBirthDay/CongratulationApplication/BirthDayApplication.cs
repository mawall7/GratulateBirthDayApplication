using GratulateBirthDay.StringExtensions;
using System;
using System.Collections.Generic;

namespace GratulateBirthDay
{
    public class BirthDayApplication
    {
        //private IReadOnlyDictionary<DateTime, string[]> _namesBirdayRegistry;
        private IPeopleRegister _peopleRegister;
        private IUserInteractor _ui;
        private IPeopleFinder _peopleFinder;

        public BirthDayApplication(IPeopleRegister peopleRegister/*IReadOnlyDictionary<DateTime, string[]> namesBirdayRegistry*/,IPeopleFinder peopleFinder, IUserInteractor consoleui)
        {
            //_namesBirdayRegistry = namesBirdayRegistry;
            _peopleRegister = peopleRegister;
            _ui = consoleui;
            _peopleFinder = peopleFinder;
        }

        public void Run()
        {
            _ui.ShowMessage("Find out a birthday of a famous person. (Return)");
            _ui.Read();
            var sampleDate = DateTime.Parse(Resource1.SampleData);

            //var searchDate = new DateTime(1963, 4, 18) use ResourceFile instead;
            var searchDate = sampleDate;

            _ui.ShowMessage($"Any famous who has birthday on " +
                $"{searchDate.Day}/{searchDate.Month} {searchDate.Year} ?." +
                $" (Press key)");

            _ui.Read();
            //IPeopleRegister register = new RegisterOfFamousPeople();

            //var famousPeopleFinder = new FamousPeopleFinder(
            //    _peopleRegister);

            var namesWithBirthday = _peopleFinder
                .FindNamesFromBirthDayAt_OrNull(searchDate);
            string foreName = default;
            if (namesWithBirthday != null)
            {
                foreach (var name in namesWithBirthday)
                {
                    Person person = (Person)name;
                    _ui.ShowMessage(person.ToString());
                    foreName = name.GetForeNameFromFullName();

                }
                _ui.ShowMessage("Happy birthday " + foreName + "!. And all of you!.");
            }
            else _ui.ShowMessage("Nope. No one known has birthday at this particular date. ");
            _ui.Read();
        }
    }
}