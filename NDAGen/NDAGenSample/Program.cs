using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiCLSApp.Facade;

namespace NDAGenSample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            await TiclsServiceSystem.GetService().RegistrationRegister();
            

        }
    }
}
