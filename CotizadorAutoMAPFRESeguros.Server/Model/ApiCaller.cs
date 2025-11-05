namespace CotizadorAutoMAPFRESeguros.Server.Model
{
    public class ApiCaller
    {
        public static HttpClient Client { get; set; }

        public static void InitializeClient()
        {
            Client = new HttpClient();
        }
    }
}
