using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay
{
    public interface IPeopleRegister
    {
        public  IReadOnlyDictionary<DateTime, string[]> NameByBirthDate { get;}
    }
}
