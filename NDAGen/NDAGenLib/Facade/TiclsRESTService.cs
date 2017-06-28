using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NDAGenLib.DataAccess;
using NDAGenLib.Model;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NDAGenLib.Facade
{
    class TiclsRESTService : IDefinitionService
    {
        RESTAccess ac;
        public TiclsRESTService()
        {
           ac = new RESTAccess("http://10.10.10.152:3000");
          // ac = new RESTAccess("http://qapp01.mindpack.com/publishoutput");
        }

        public async Task<ServiceDef> RegistrationRegister()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            string requestJson = await ac.Request("swagger/v1/swagger.json", "GET", param, "");
            var result = JsonConvert.DeserializeObject<SwaggerDef>(requestJson);
            var ServiceDefinition = new ServiceDef();
            ServiceDefinition.ModelDefinitions = new List<DTODef>();
            ServiceDefinition.Paths = new List<DTOSwaggerPath>();
            JObject o = JObject.Parse(requestJson);
            var definitions = o["definitions"];
            foreach (JProperty item in definitions)
            {
                try
                {
                    var Defininition = new DTODef();
                    var PropList = new List<DTODefProps>();
                    Defininition.ModelName = item.Name;

                    var StepIn = item.Value;
                    var Props = StepIn["properties"];
                    foreach (JProperty prop in Props)
                    {
                        var Prop = new DTODefProps();

                        Prop.Name = prop.Name;
                        Prop.Type = prop.Value["type"].Value<string>();
                        PropList.Add(Prop);
                    }
                    Defininition.ModelProps = PropList;
                    ServiceDefinition.ModelDefinitions.Add(Defininition);
                }
                catch (Exception ex)
                {

                   int a = 3;
                }
            }

            var Paths = o["paths"];
            foreach (JProperty item in Paths)
            {
                try
                {
                    var Path = new DTOSwaggerPath();
                    Path.Actions = new List<DTOSwaggerPathsAction>();
                    Path.Path = item.Name;
                    var StepIn = item.Value;
                    //var Props = StepIn["properties"];
                    foreach (JProperty action in StepIn)
                    {
                        var Action = new DTOSwaggerPathsAction();
                        Action.ActionName = action.Name;
                        Action.Parameters = new List<DTOSwaggerPathsParameter>();
                        Action.Responses = new List<DTOSwaggerPathsResponse>();

                        var StepInAction = action.Value;
                        JsonSerializer serial = new JsonSerializer();
                        serial.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        Action.Parameters = StepInAction["parameters"]?.ToObject<List<DTOSwaggerPathsParameter>>(serial);
                        foreach (JProperty resp in StepInAction["responses"])
                        {
                            JsonSerializerSettings settings = new JsonSerializerSettings();
                            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                            var Response = resp.Value.ToObject<DTOSwaggerPathsResponse>(serial);
                            Response.StatusCode = resp.Name;
                            Action.Responses.Add(Response);
                        }
                        

                        Path.Actions.Add(Action);
                    }

                    ServiceDefinition.Paths.Add(Path);
                }
                catch (Exception ex)
                {

                    int a = 3;
                }
            }
            return ServiceDefinition;
        }
    }
}
