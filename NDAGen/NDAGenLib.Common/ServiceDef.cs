using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Common
{
    public class ServiceDef
    {
        public List<DTODef> ModelDefinitions { get; set; }
        public List<DTOMethodPath> Paths { get; set; }
    }
}
