using Microsoft.JSInterop;

namespace CotizadorAutoMAPRESeguros.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static ValueTask<object> GuardarLocalStore(this IJSRuntime js,
        string llave, string contenido)
        {
            return js.InvokeAsync<object>("localStorage.setItem", llave, contenido);
        }

        public static ValueTask<object> ObtenerLocalStore(this IJSRuntime js,
            string llave)
        {
            return js.InvokeAsync<object>("localStorage.getItem", llave);
        }

        public static ValueTask<object> RemoverLocalStore(this IJSRuntime js,
            string llave)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", llave);
        }
    }
}
