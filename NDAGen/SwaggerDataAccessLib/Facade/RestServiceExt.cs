using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticls.Model;
using TiclsDataAccessLib.DataAccess;

namespace Ticls.Facade
{
    public class TiclsRESTServiceExt : TiclsRESTService
    {

        public TiclsRESTServiceExt(IRestAccess access) : base(access)
        {
        }
        public override async Task<DTORespConnectToken> connecttokenpost(OpenIdConnectRequest request)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("api_key", "apiKey");
            string postData = "grant_type=" + request.grantType + "&password=" + request.password + "&username=" + request.username + "&scope" + request.scope;// + "&ressource=" + login.ressource;
            string requestJson = await ac.Request("connect/token", "POST", param, "", postData, "application/x-www-form-urlencoded");
            //var obj = Newtonsoft.Json.Linq.JObject.Parse(requestJson);
            // var token = (string)obj["access_token"];
            //return new OpenIdConnectRequest() { accessToken = token };
            DTORespConnectToken result = JsonConvert.DeserializeObject<DTORespConnectToken>(requestJson);
            return result;
        }

    }
}
