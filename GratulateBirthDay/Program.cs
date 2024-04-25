using GratulateBirthDay.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GratulateBirthDay
{
    public class Program
    {
        static void Main(string[] args)
        {
             
            var _consoleui = new ConsoleUserInteractor();
            IPeopleRegister Register = new RegisterOfFamousPeople(); 

            try
            {
                var NamesBirthdayRegister  = new RegisterOfFamousPeople()
                    .ReadAll();

                var BirthdayApplication = new BirthDayApplication(Register, new FamousPeopleFinder(Register), _consoleui);
                BirthdayApplication.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error on execution. {e.Message}");
                
            }
            
            
        }
    }
}
