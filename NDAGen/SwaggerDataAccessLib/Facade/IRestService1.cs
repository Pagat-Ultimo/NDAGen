
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Model;    

namespace PetStore.Facade    
{
    public interface IPetStoreService
    {
		string Token { get; set; }
		Task petpost(Pet body);
		Task petput(Pet body);
		Task<List<Pet>> petfindByStatusget(List<string> status);
		Task<List<Pet>> petfindByTagsget(List<string> tags);
		Task<Pet> petpetIdget(int petId);
		Task petpetIdpost(int petId, string name, string status);
		Task petpetIddelete(string api_key, int petId);
		Task<ApiResponse> petpetIduploadImagepost(int petId, string additionalMetadata, string file);
		
		Task<Order> storeorderpost(Order body);
		Task<Order> storeorderorderIdget(int orderId);
		Task storeorderorderIddelete(int orderId);
		Task userpost(User body);
		Task usercreateWithArraypost(List<User> body);
		Task usercreateWithListpost(List<User> body);
		
		Task userlogoutget();
		Task<User> userusernameget(string username);
		Task userusernameput(string username, User body);
		Task userusernamedelete(string username);
  
    }
}