
using System.Text;
using System.Threading.Tasks;
using System.IO; 
using Newtonsoft.Json.Linq; 
using System.Collections.Generic; 
using Newtonsoft.Json; 
using SwaggerDataAccessLib.DataAccess;
using PetStore.Model;
 
namespace PetStore.Facade
{
	public partial class PetStoreService : IPetStoreService
	{
        protected IRestAccess ac;   
		public string Token { get; set; } = "";
        public PetStoreService(IRestAccess access)
        {
		   ac = access;
		   ac.ConnectionString = "http://petstore.swagger.io/#/"; 
        }
				public virtual async Task petpost(Pet body)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet", "POST", param, Token, JsonConvert.SerializeObject(body) );
		}
		public virtual async Task petput(Pet body)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet", "PUT", param, Token, JsonConvert.SerializeObject(body) );
		}
		public virtual async Task<List<Pet>> petfindByStatusget(List<string> status)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
		    param.Add("status",status.ToString());
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet/findByStatus", "GET", param, Token, null );
			List<Pet> result = JsonConvert.DeserializeObject<List<Pet>>(requestJson);
			return result;
		}
		public virtual async Task<List<Pet>> petfindByTagsget(List<string> tags)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
		    param.Add("tags",tags.ToString());
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet/findByTags", "GET", param, Token, null );
			List<Pet> result = JsonConvert.DeserializeObject<List<Pet>>(requestJson);
			return result;
		}
		public virtual async Task<Pet> petpetIdget(int petId)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet/" + petId + "", "GET", param, Token, null );
			Pet result = JsonConvert.DeserializeObject<Pet>(requestJson);
			return result;
		}
		public virtual async Task petpetIdpost(int petId, string name, string status)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet/" + petId + "", "POST", param, Token, null );
		}
		public virtual async Task petpetIddelete(string api_key, int petId)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet/" + petId + "", "DELETE", param, Token, null );
		}
		public virtual async Task<ApiResponse> petpetIduploadImagepost(int petId, string additionalMetadata, string file)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/pet/" + petId + "/uploadImage", "POST", param, Token, null );
			ApiResponse result = JsonConvert.DeserializeObject<ApiResponse>(requestJson);
			return result;
		}
		public virtual async Task<Order> storeorderpost(Order body)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/store/order", "POST", param, Token, JsonConvert.SerializeObject(body) );
			Order result = JsonConvert.DeserializeObject<Order>(requestJson);
			return result;
		}
		public virtual async Task<Order> storeorderorderIdget(int orderId)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/store/order/" + orderId + "", "GET", param, Token, null );
			Order result = JsonConvert.DeserializeObject<Order>(requestJson);
			return result;
		}
		public virtual async Task storeorderorderIddelete(int orderId)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/store/order/" + orderId + "", "DELETE", param, Token, null );
		}
		public virtual async Task userpost(User body)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/user", "POST", param, Token, JsonConvert.SerializeObject(body) );
		}
		public virtual async Task usercreateWithArraypost(List<User> body)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/user/createWithArray", "POST", param, Token, JsonConvert.SerializeObject(body) );
		}
		public virtual async Task usercreateWithListpost(List<User> body)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/user/createWithList", "POST", param, Token, JsonConvert.SerializeObject(body) );
		}
		public virtual async Task userlogoutget()
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/user/logout", "GET", param, Token, null );
		}
		public virtual async Task<User> userusernameget(string username)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/user/" + username + "", "GET", param, Token, null );
			User result = JsonConvert.DeserializeObject<User>(requestJson);
			return result;
		}
		public virtual async Task userusernameput(string username, User body)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/user/" + username + "", "PUT", param, Token, JsonConvert.SerializeObject(body) );
		}
		public virtual async Task userusernamedelete(string username)
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			//param.Add("api_key", "apiKey");
			string requestJson = await ac.Request("/user/" + username + "", "DELETE", param, Token, null );
		}
  
		
	}
}