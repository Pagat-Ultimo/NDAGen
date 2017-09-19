using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Swagger
{
    public class SwaggerDef
    {
        public string Swagger { get; set; }
        public SwaggerInfo Info { get; set; }
    }

    public class SwaggerInfoContact
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
    }

    public class SwaggerInfo
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public SwaggerInfoContact Contact { get; set; }
    }
}
