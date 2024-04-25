using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratulateBirthDay
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        #nullable enable
        public string? Read(string? promptmessage = null)
        {
            if (!string.IsNullOrEmpty(promptmessage))
            {
                Console.WriteLine(promptmessage);
            }
            
            return Console.ReadLine();

        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
