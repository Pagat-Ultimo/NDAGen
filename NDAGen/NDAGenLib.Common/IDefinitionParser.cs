using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Common
{
    public interface IDefinitionParser
    {
        ServiceDef ParseDefinition(string serviceDefintion);
    }
}
