using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Common
{
    public interface IDefinitionService
    {
        Task<string> RetrieveDefinition();
    }
}
