using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Model
{
    public class DTODef
    {
        public string ModelName { get; set; }
        public List<DTODefProps> ModelProps { get; set; }
    }

    public class DTODefProps
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
