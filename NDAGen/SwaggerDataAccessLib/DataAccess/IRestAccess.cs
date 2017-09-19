using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerDataAccessLib.DataAccess
{
    public interface IRestAccess
    {
        string ConnectionString { get; set; }
        Task<string> Request(string method, string requestType, Dictionary<string, string> param, string AuthToken = "", string postData = null, string contentType = "application/json");
    }
}
