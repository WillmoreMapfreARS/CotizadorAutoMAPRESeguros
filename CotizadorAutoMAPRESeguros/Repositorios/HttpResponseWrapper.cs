namespace CotizadorAutoMAPRESeguros.Client.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response,bool error, HttpResponseMessage httpResponseMessage) {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> ObtenerError()
        {

            if (!Error)
            {
                return null;
            }

            var codigoEstatus = HttpResponseMessage.StatusCode;

            if (codigoEstatus == System.Net.HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";
            }
            else if (codigoEstatus == System.Net.HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == System.Net.HttpStatusCode.Forbidden)
            {
                return "No tiene permiso para hacer esto";
            }
            else if (codigoEstatus == System.Net.HttpStatusCode.Unauthorized)
            {
                return "Sesión vencida.";
            }
            else
            {
                return "Ha ocurrido un error inesperado";
            }
        }

    }
}
