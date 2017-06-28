using NDAGenLib.Model;
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
            ServiceDefinition = await TiclsServiceSystem.GetService().RegistrationRegister();

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
        public string GetMethodTypeFromSchema(DTOSwaggerPathsRespinseSchemaItem reference)
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

        public string JsonTypeToNetType(string type)
        {
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
                default:
                    return type;
            }
        }

        public string GetParamList(List<DTOSwaggerPathsParameter> param)
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
                    ParamList += JsonTypeToNetType(item.Type);
                }
                else
                {
                    if (Schema.Items == null)
                    {
                        if(Schema.TypeRef != null)
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

        public string GetMethodHead(DTOSwaggerPathsAction action, string path, bool isPublic, bool isAsync = false)
        {
            string Head = "";
            if (isPublic)
                Head += "public ";
            if (isAsync)
                Head += "async ";
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

        public string GetMethodType(DTOSwaggerPathsAction action)
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

        public string GetPath(DTOSwaggerPath path)
        {
            var Path = "\"";
            Path += path.Path.Replace("#", "");
            Path = Path.Replace("{", "\" + ");
            Path = Path.Replace("}", " + \"");
            if (Path[Path.Length-2] == '\"')
                Path.Remove(Path.Length - 4,4);
            else
                Path+="\"";
            return Path;
        }
        public string GetBodyParamName(List<DTOSwaggerPathsParameter> param)
        {
            if (param == null)
                return "";
            var Param = param.Where(x => x.In == "body").FirstOrDefault();
            if (Param != null)
                return Param.Name;
            else
                return "";
        }
        public string GetBodyParamType(List<DTOSwaggerPathsParameter> param)
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
        public string GetBodyParamSerialization(List<DTOSwaggerPathsParameter> param)
        {
            string BodyParamName = GetBodyParamName(param);
            if (BodyParamName == "")
                return "null";
            else
                return "JsonConvert.SerializeObject(" + BodyParamName + ")";
        }
    }
}
