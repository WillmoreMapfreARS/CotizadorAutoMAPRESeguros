using CotizadorAutoMAPRESeguros.Client.Repositorios;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace CotizadorAutoMAPRESeguros
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var http = new HttpClient();

            //// 1. Leer el JSON remoto o local (esto asume que es accesible por URL o ruta relativa en servidor)
            //var stream = await http.GetStreamAsync("appsettings.json");

            //// 2. Construir IConfiguration desde el stream
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            //// 3. Leer valores del config
            var urlbase = config["baseUrl"]!;

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlbase) }); //builder.HostEnvironment.BaseAddress
            builder.Services.AddScoped<IRepositorio, Repositorio>();
            builder.Services.AddMudServices();
            builder.Services.AddSweetAlert2();
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US") { NumberFormat = { CurrencyDecimalDigits = 2 } };
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US") { NumberFormat = { CurrencyDecimalDigits = 2 } };

            await builder.Build().RunAsync();
        }
    }
}
