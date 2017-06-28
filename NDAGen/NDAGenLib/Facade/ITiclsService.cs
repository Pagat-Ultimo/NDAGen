using NDAGenLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Facade
{
    public interface IDefinitionService
    {
        Task<ServiceDef> RegistrationRegister();
    }
}
