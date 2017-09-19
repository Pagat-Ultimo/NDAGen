using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Common
{
    public class DTOMethodPath
    {
        public string Path { get; set; }
        public List<DTOMethodPathsAction> Actions { get; set; }
    }

    public class DTOMethodPathsAction
    {
        public string ActionName { get; set; }
        public List<DTOMethodPathsParameter> Parameters { get; set; }
        public List<DTOMethodPathsResponse> Responses { get; set; }
    }

    public class DTOMethodPathsParameter
    {
        public string Name { get; set; }
        public string In { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
        public DTOMethodPathsResponseSchema Schema { get; set; }
        public DTOMethodPathsRespinseSchemaItem Items { get; set; }
    }

    public class DTOMethodPathsResponse
    {
        public string StatusCode { get; set; }
        public string Description { get; set; }
        public DTOMethodPathsResponseSchema Schema { get; set; }

    }

    public class DTOMethodPathsResponseSchema
    {
        public string Type { get; set; }
        [JsonProperty("$ref")]
        public string TypeRef { get; set; }
        public DTOMethodPathsRespinseSchemaItem Items { get; set; }
    }

    public class DTOMethodPathsRespinseSchemaItem
    {
        [JsonProperty("$ref")]
        public string TypeRef { get; set; }
        public string Type { get; set; }
    }
}
