using NDAGenLib.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Swagger
{
    public class NDASwaggerDefinitionParser : IDefinitionParser
    {
        public ServiceDef ParseDefinition(string serviceDefintion)
        {
            var ServiceDefinition = new ServiceDef();
            
            JObject o = JObject.Parse(serviceDefintion);
            var ModelDef = o["definitions"];
            ServiceDefinition.ModelDefinitions = ParseModelDefs(ModelDef);
            var Paths = o["paths"];
            ServiceDefinition.Paths = ParsePathDefs(Paths);
            return ServiceDefinition;
        }

        List<DTODef> ParseModelDefs(JToken ModelDefs)
        {
            var ModelDefList = new List<DTODef>();
            foreach (JProperty MDef in ModelDefs)
            {
                try
                {
                    var Defininition = new DTODef();
                    
                    Defininition.ModelName = MDef.Name;

                    var Props = MDef.Value["properties"];
                    
                    Defininition.ModelProps = ParsePropertiesFromModelDef(Props);
                    ModelDefList.Add(Defininition);
                }
                catch (Exception ex)
                {
                    int a = 3;
                }
            }
            return ModelDefList;
        }

        List<DTOMethodPath> ParsePathDefs(JToken PathDefs)
        {
            var PathDefsList = new List<DTOMethodPath>();
            foreach (JProperty item in PathDefs)
            {
                try
                {
                    var Path = new DTOMethodPath();
                    Path.Actions = new List<DTOMethodPathsAction>();
                    Path.Path = item.Name;
                    var StepIn = item.Value;
                    foreach (JProperty action in StepIn)
                    {
                        var Action = new DTOMethodPathsAction();
                        Action.ActionName = action.Name;
                        Action.Parameters = new List<DTOMethodPathsParameter>();
                        Action.Responses = new List<DTOMethodPathsResponse>();

                        var StepInAction = action.Value;
                        JsonSerializer serial = new JsonSerializer();
                        serial.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        Action.Parameters = StepInAction["parameters"]?.ToObject<List<DTOMethodPathsParameter>>(serial);
                        foreach (JProperty resp in StepInAction["responses"])
                        {
                            JsonSerializerSettings settings = new JsonSerializerSettings();
                            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                            var Response = resp.Value.ToObject<DTOMethodPathsResponse>(serial);
                            Response.StatusCode = resp.Name;
                            Action.Responses.Add(Response);
                        }


                        Path.Actions.Add(Action);
                    }

                    PathDefsList.Add(Path);
                }
                catch (Exception ex)
                {

                    int a = 3;
                }
            }
            return PathDefsList;
        }

        List<DTODefProps> ParsePropertiesFromModelDef(JToken modelDef)
        {
            var PropList = new List<DTODefProps>();
            foreach (JProperty prop in modelDef)
            {
                var Prop = new DTODefProps();

                Prop.Name = prop.Name;
                if (prop.Value["type"] == null)
                {
                    Prop.ReferenceType = prop.Value["$ref"].Value<string>();
                }
                else
                {
                    Prop.Type = prop.Value["type"].Value<string>();
                    var ItemProp = prop.Value["items"];
                    if (ItemProp != null)
                    {
                        if (ItemProp["$ref"] != null)
                            Prop.ReferenceType = ItemProp["$ref"].Value<string>();
                        else
                            Prop.ReferenceType = ItemProp["type"].Value<string>();
                    }
                }
                PropList.Add(Prop);
            }
            return PropList;
        }
    }
}
