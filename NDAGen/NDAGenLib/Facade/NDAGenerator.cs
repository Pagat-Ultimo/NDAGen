using NDAGenLib.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAGenLib.Facade
{
    public class NDAGenerator
    {
        public ServiceDef ServiceDefinition { get; set; }

        public NDAGenerator()
        {
            MainAsync().Wait();
        }

        async Task MainAsync()
        {
            string Definition = await NDAServiceSystem.GetService().RetrieveDefinition();
            ServiceDefinition = NDAServiceSystem.GetParser().ParseDefinition(Definition); 

        }

        public List<DTODefProps> GetProperties()
        {

            return ServiceDefinition.ModelDefinitions.First().ModelProps;
        }
        public string GetMethodNameFromPath(string path)
        {
            path = path.Replace("/", "");
            path = path.Replace("#", "");
            path = path.Replace("{", "");
            path = path.Replace("}", "");
            return path;
        }
        public string GetMethodTypeFromSchema(DTOMethodPathsRespinseSchemaItem reference)
        {
            var ActualType = "";
            if (reference.TypeRef != null)
            {
                ActualType = reference.TypeRef;
                return GetMethodTypeFromRef(ActualType);
            }
            else
                return reference.Type;

        }
        public string GetMethodTypeFromRef(string reference)
        {

            reference = reference.Replace("#", "");
            return Path.GetFileName(reference);

        }

        public string JsonTypeToNetType(string type, string refType = "")
        {
            if (refType == null)
                refType = "";
            switch (type)
            {
                case "number":
                    return "double";
                case "integer":
                    return "int";
                case "boolean":
                    return "bool";
                case "object":
                    return "dynamic";
                case "timestamp":
                    return "DateTime";
                case "array":
                    return "List<" + GetMethodTypeFromRef(refType) + ">";
                case "file":
                    return "string";
                case null:
                    return GetMethodTypeFromRef(refType);
                default:
                    return type;
            }
        }

        public string GetParamList(List<DTOMethodPathsParameter> param)
        {
            string ParamList = "";
            if (param == null)
                return "";
            foreach (var item in param)
            {
                if (ParamList != "")
                    ParamList += ", ";
                var Schema = item.Schema;
                if (Schema == null)
                {
                    ParamList += JsonTypeToNetType(item.Type, (item.Items == null ? "" : item.Items.Type));
                }
                else
                {
                    if (Schema.Items == null)
                    {
                        if (Schema.TypeRef != null)
                            ParamList += GetMethodTypeFromRef(Schema.TypeRef);
                        else
                            ParamList += JsonTypeToNetType(Schema.Type);
                    }
                    else
                    {
                        ParamList += "List<" + GetMethodTypeFromSchema(Schema.Items) + ">";
                    }
                }

                ParamList += " " + item.Name;
            }
            return ParamList;
        }

        public string GetMethodHead(DTOMethodPathsAction action, string path, string preClause = "")
        {
            try
            {
                string Head = "";
                Head += preClause;
                Head += "Task";
                var resp = action.Responses.First();
                if (resp != null)
                {
                    var Schema = resp.Schema;
                    if (Schema == null)
                    {
                        Head += " " + GetMethodNameFromPath(path) + action.ActionName;
                    }
                    else
                    {
                        if (Schema.Items == null)
                        {
                            Head += "<" + GetMethodTypeFromRef(Schema.TypeRef) + "> " + GetMethodNameFromPath(path) + action.ActionName;
                        }
                        else
                        {
                            Head += "<List<" + GetMethodTypeFromSchema(Schema.Items) + ">> " + GetMethodNameFromPath(path) + action.ActionName;
                        }
                    }
                }
                Head += "(";
                Head += GetParamList(action.Parameters);
                Head += ")";
                return Head;
            }
            catch (Exception)
            {
                return "";
            }


        }

        public string GetMethodType(DTOMethodPathsAction action)
        {
            var resp = action.Responses.First();
            if (resp != null)
            {
                var Schema = resp.Schema;
                if (Schema == null)
                {
                    return "";
                }
                else
                {
                    if (Schema.Items == null)
                    {
                        return GetMethodTypeFromRef(Schema.TypeRef);
                    }
                    else
                    {
                        return "List<" + GetMethodTypeFromSchema(Schema.Items) + ">";
                    }
                }
            }
            return "";
        }

        public string GetPath(DTOMethodPath path)
        {
            var Path = "\"";
            Path += path.Path.Replace("#", "");
            Path = Path.Replace("{", "\" + ");
            Path = Path.Replace("}", " + \"");
            if (Path[Path.Length - 2] == '\"')
                Path.Remove(Path.Length - 4, 4);
            else
                Path += "\"";
            return Path;
        }
        public string GetBodyParamName(List<DTOMethodPathsParameter> param)
        {
            if (param == null)
                return "";
            var Param = param.Where(x => x.In == "body").FirstOrDefault();
            if (Param != null)
                return Param.Name;
            else
                return "";
        }
        public string GetBodyParamType(List<DTOMethodPathsParameter> param)
        {
            string ParamList = "";
            if (param == null)
                return "";
            foreach (var item in param)
            {
                if (item.In != "body")
                    continue;
                if (ParamList != "")
                    ParamList += ", ";
                var Schema = item.Schema;
                if (Schema == null)
                {
                    ParamList += JsonTypeToNetType(item.Type);
                }
                else
                {
                    if (Schema.Items == null)
                    {
                        if (Schema.TypeRef != null)
                            ParamList += GetMethodTypeFromRef(Schema.TypeRef);
                        else
                            ParamList += JsonTypeToNetType(Schema.Type);
                    }
                    else
                    {
                        ParamList += GetMethodTypeFromSchema(Schema.Items);
                    }
                }

                break;
            }
            return ParamList;
        }
        public string GetBodyParamSerialization(List<DTOMethodPathsParameter> param)
        {
            string BodyParamName = GetBodyParamName(param);
            if (BodyParamName == "")
                return "null";
            else
                return "JsonConvert.SerializeObject(" + BodyParamName + ")";
        }

        public string GetQueryParamKeyValueString(DTOMethodPathsParameter param)
        {
            string result = "";
            if (param == null)
                return "";
            if (param.In == "query")
            {
                return "\"" + param.Name + "\"," + param.Name;
            }
            else return "";
        }
    }
}
