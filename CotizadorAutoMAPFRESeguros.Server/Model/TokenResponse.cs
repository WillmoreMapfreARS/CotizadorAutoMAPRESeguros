namespace CotizadorAutoMAPFRESeguros.Server.Model
{
    public class TokenResponse
    {
        public string token { get; set; }
        public string exp { get; set; }
        public string refreshToken { get; set; }

    }
}
