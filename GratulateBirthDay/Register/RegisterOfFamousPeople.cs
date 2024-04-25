using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay
{
    public class RegisterOfFamousPeople : IPeopleRegister
    {
       
        public IReadOnlyDictionary<DateTime, string[]> NameByBirthDate
        {
            get 
            {
               return new Dictionary<DateTime, string[]>
                {
                    {new DateTime(1962, 10, 16),new []{"Steve Carrel","Unknown"} },
                    {new DateTime(1978, 12, 18),new[]{"Cathy Holmes" } },
                    {new DateTime(1982, 4, 13),new []{"Kirsten Dunst"} },
                    {new DateTime(1963, 4, 18),new []{"Conan O'Brien"} }
                };
            } 
        }

        public IReadOnlyDictionary<DateTime, string[]> ReadAll()
        {
            return NameByBirthDate;
        }
            

        

    }
}
