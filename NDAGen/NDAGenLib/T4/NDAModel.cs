  
namespace NDA.Model
{
    public class DTORespAccountGet
    {
        public string text { get; set; }
        public string valueChanged { get; set; }
	} 
    public class DTOReqAccountCheckout
    {
        public double table_sum_orig { get; set; }
        public double credit_used { get; set; }
        public int sysNo { get; set; }
        public int orderID { get; set; }
	} 
    public class DTOReqAccountPayInfo
    {
        public double tableSum { get; set; }
        public int sysNo { get; set; }
        public int orderID { get; set; }
	} 
    public class DTORespAccountPayInfo
    {
        public string id { get; set; }
        public double newPoints { get; set; }
        public double currentPoints { get; set; }
        public double discount { get; set; }
        public double credit { get; set; }
	} 
    public class OpenIdConnectRequest
    {
        public string accessToken { get; set; }
        public string acrValues { get; set; }
        public string assertion { get; set; }
        public dynamic claims { get; set; }
        public string claimsLocales { get; set; }
        public string clientAssertion { get; set; }
        public string clientAssertionType { get; set; }
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string code { get; set; }
        public string codeChallenge { get; set; }
        public string codeChallengeMethod { get; set; }
        public string codeVerifier { get; set; }
        public string display { get; set; }
        public string grantType { get; set; }
        public string identityProvider { get; set; }
        public string idTokenHint { get; set; }
        public string loginHint { get; set; }
        public int maxAge { get; set; }
        public string nonce { get; set; }
        public string password { get; set; }
        public string postLogoutRedirectUri { get; set; }
        public string prompt { get; set; }
        public string redirectUri { get; set; }
        public string refreshToken { get; set; }
        public string request { get; set; }
        public string requestId { get; set; }
        public string requestUri { get; set; }
        public string resource { get; set; }
        public string responseMode { get; set; }
        public string responseType { get; set; }
        public string scope { get; set; }
        public string state { get; set; }
        public string token { get; set; }
        public string tokenTypeHint { get; set; }
        public dynamic registration { get; set; }
        public string uiLocales { get; set; }
        public string username { get; set; }
	} 
    public class DTORespLocationGet
    {
        public int locatinId { get; set; }
        public string name { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public bool subscribed { get; set; }
	} 
    public class DTOReqLocationsSubscribe
    {
        public string userId { get; set; }
        public bool subscribe { get; set; }
        public int locationId { get; set; }
	} 
    public class DTOTiclsUser
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public double credit { get; set; }
        public double points { get; set; }
        public string phoneNumber { get; set; }
        public string cardCode { get; set; }
        public string passwordHash { get; set; }
	} 
}
