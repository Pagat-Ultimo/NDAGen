using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Model
{
    public class DTOSwaggerPath
    {
        public string Path { get; set; }
        public List<DTOSwaggerPathsAction> Actions { get; set; }
    }

    public class DTOSwaggerPathsAction
    {
        public string ActionName { get; set; }
        public List<DTOSwaggerPathsParameter> Parameters { get; set; }
        public List<DTOSwaggerPathsResponse> Responses { get; set; }
    }

    public class DTOSwaggerPathsParameter
    {
        public string Name { get; set; }
        public string In { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
        public DTOSwaggerPathsResponseSchema Schema { get; set; }
    }

    public class DTOSwaggerPathsResponse
    {
        public string StatusCode { get; set; }
        public string Description { get; set; }
        public DTOSwaggerPathsResponseSchema Schema { get; set; }

    }

    public class DTOSwaggerPathsResponseSchema
    {
        public string Type { get; set; }
        [JsonProperty("$ref")]
        public string TypeRef { get; set; }
        public DTOSwaggerPathsRespinseSchemaItem Items { get; set; }
    }

    public class DTOSwaggerPathsRespinseSchemaItem
    {
        [JsonProperty("$ref")]
        public string TypeRef { get; set; }
        public string Type { get; set; }
    }
}
