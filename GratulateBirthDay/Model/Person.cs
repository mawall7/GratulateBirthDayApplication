using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay
{
    public class Person
    {
        private string _fullName { get; }

        public Person(string Name)
        {
            _fullName = Name;
        }
        public override string ToString()
        {
            return $"It's {_fullName}'s birthday!.";
        }

        public static explicit operator Person(string name)
        {
            return new Person(name);
        }
        
        
    }
}
