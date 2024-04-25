using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay
{
    public interface IUserInteractor
    {
        #nullable enable
        public string? Read(string? promptmessage = null);
        public void ShowMessage(string message);
        
    }
}



        

