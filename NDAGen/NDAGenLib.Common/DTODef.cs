using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Common
{
    public class DTODef
    {
        public string ModelName { get; set; }
        public string ProtocollName { get; set; }
        public List<DTODefProps> ModelProps { get; set; }
    }

    public class DTODefProps
    {
        public string Name { get; set; }
        public string ProtocollName { get; set; }
        public string Type { get; set; }
        public string ReferenceType { get; set; }
    }
}
