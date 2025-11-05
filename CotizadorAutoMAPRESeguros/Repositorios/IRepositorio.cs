using System.Text.Json;

namespace CotizadorAutoMAPRESeguros.Client.Repositorios
{
    public interface IRepositorio
    {
        Task ConstruirAuthenticationStateAsync();
        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<T> DeserializarRespuesta<T>(HttpResponseMessage message, JsonSerializerOptions jsonSerializerOptions);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar);


    }
}
