using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace CotizadorAutoMAPFRESeguros.Server.Model
{
    public class CotizacionToken
    {
        private readonly IConfiguration configuration;
        readonly string user;
        readonly string password;
        private string tokenurl;
   

        public CotizacionToken(IConfiguration configuration)
        {
            EncryptArs.Encrypt encrypt = new EncryptArs.Encrypt();
           
            this.configuration = configuration;
            this.user = configuration["user"]!;
            this.password = encrypt.Decrypt(configuration["password"]!);

            this.tokenurl = configuration["token"]!;
        }

        public async Task<TokenResponse> GetToken()
        {
            
            var dictionaryForLogin = new Dictionary<string, string>
            {
              
                {"username",user},
                {"password",password}
            };

            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));


            HttpContent httpContent = new FormUrlEncodedContent(dictionaryForLogin);
            ApiCaller.Client.DefaultRequestHeaders.Accept.Clear();
            ApiCaller.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            string responseString = string.Empty;
            using (var message = await ApiCaller.Client.PostAsync(tokenurl, httpContent))
            {
                responseString = await message.Content.ReadAsStringAsync();
            }

            JObject obj = JObject.Parse(responseString);

            TokenResponse responseAfterAuth = new TokenResponse();
            responseAfterAuth.token = (string)obj["token"];
            responseAfterAuth.exp = (string)obj["exp"];
            responseAfterAuth.refreshToken = (string)obj["refreshToken"];
         

            return responseAfterAuth;
        }

    }
}
