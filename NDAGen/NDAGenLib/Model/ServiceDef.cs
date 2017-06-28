using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Model
{
    public class ServiceDef
    {
        public List<DTODef> ModelDefinitions { get; set; }
        public List<DTOSwaggerPath> Paths { get; set; }
    }
}
