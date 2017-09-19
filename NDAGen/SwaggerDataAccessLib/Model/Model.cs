
 
using System.Collections.Generic;

namespace PetStore.Model    
{    
    public class Order
    {
        public int id { get; set; }
        public int petId { get; set; }
        public int quantity { get; set; }
        public string shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }
	} 
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
	} 
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public int userStatus { get; set; }
	} 
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
	} 
    public class Pet
    {
        public int id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public List<string> photoUrls { get; set; }
        public List<Tag> tags { get; set; }
        public string status { get; set; }
	} 
    public class ApiResponse
    {
        public int code { get; set; }
        public string type { get; set; }
        public string message { get; set; }
	} 
}
