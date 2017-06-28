using System;
using System.Collections.Generic;
using System.Text;

namespace NDAGenLib.Facade
{
    public class TiclsServiceSystem
    {
        public TiclsServiceSystem()
        {

        }

        public static IDefinitionService GetService()
        {
            return new TiclsRESTService();
        }

        
    }
}
