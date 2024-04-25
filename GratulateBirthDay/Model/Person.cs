using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay
{
    public class Person
    {
        private string _fullname { get; }

        public Person(string Name)
        {
            _fullname = Name;
        }
        public override string ToString()
        {
            return $"It's {_fullname}'s birthday!.";
        }

        public static explicit operator Person(string name)
        {
            return new Person(name);
        }
        
        
    }
}
