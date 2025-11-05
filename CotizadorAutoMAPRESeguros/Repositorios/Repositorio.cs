using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using CotizadorAutoMAPRESeguros.Client.Helpers;



namespace CotizadorAutoMAPRESeguros.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;
        private readonly IJSRuntime js;
        private readonly NavigationManager navigation;
        private JsonSerializerOptions JsonSerializerOptionsDefault = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        public IConfiguration Configuration { get; }

        public Repositorio(HttpClient httpClient, IJSRuntime js, NavigationManager navigation,IConfiguration configuration)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            var apikey = configuration["APIKEY"]!;
            httpClient.DefaultRequestHeaders.Add("x-api-key", apikey);
            this.httpClient = httpClient;
            this.js = js;
            this.navigation = navigation;
            Configuration = configuration;
        }
        private async Task validaToken()
        {
            if (httpClient.DefaultRequestHeaders.Authorization == null)
            {
                await ConstruirAuthenticationStateAsync();
            }
        }
        private void NoAutenticado(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                navigation.NavigateTo("login");
            }
        }
        public async Task ConstruirAuthenticationStateAsync()
        {
            var token = await js.ObtenerLocalStore("TOKENKEY");
            if (token != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.ToString());
            }
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            await validaToken();
            var response = await httpClient.DeleteAsync(url);
            NoAutenticado(response);
            return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
        }

        public async Task<T> DeserializarRespuesta<T>(HttpResponseMessage message, JsonSerializerOptions jsonSerializerOptions)
        {
            await validaToken();
            var response = await message.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response, jsonSerializerOptions);
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            await validaToken();
            try
            {
                
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await DeserializarRespuesta<T>(response, JsonSerializerOptionsDefault);
                    return new HttpResponseWrapper<T>(result, false, response);
                }
                else
                {
                    NoAutenticado(response);

                    return new HttpResponseWrapper<T>(default, true, response);
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            await validaToken();
            var jsonData = JsonSerializer.Serialize(enviar);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            NoAutenticado(response);
            return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);

        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            await validaToken();
            var jsonData = JsonSerializer.Serialize(enviar);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            content.Headers.ContentLength = jsonData.Length;
            var response = await httpClient.PostAsync(url, content);
            var mensaje=  await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = await DeserializarRespuesta<TResponse>(response, JsonSerializerOptionsDefault);
                return new HttpResponseWrapper<TResponse>(result, false, response);
            }
            NoAutenticado(response);

            return new HttpResponseWrapper<TResponse>(default, !response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            await validaToken();
            var enviarJson = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, enviarContent);
            NoAutenticado(responseHttp);

            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }


    }
}
