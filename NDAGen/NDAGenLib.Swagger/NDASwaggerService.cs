using NDAGenLib.Common;
using NDAGenLib.Common.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Swagger
{
    public class NDASwaggerService : IDefinitionService
    {
        RESTAccess ac;
        public NDASwaggerService()
        {
            ac = new RESTAccess(NDAConfig.ConnectionString); 
        }
        public async Task<string> RetrieveDefinition()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            string requestJson = await ac.Request(NDAConfig.Path, "GET", param, "");
            var result = JsonConvert.DeserializeObject<SwaggerDef>(requestJson);
            return requestJson;
        }
    }
}
