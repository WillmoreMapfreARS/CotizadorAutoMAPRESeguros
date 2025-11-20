using CotizadorAutoMAPFRESeguros.Server.Auth;
using CotizadorAutoMAPFRESeguros.Server.Model;
using CotizadorAutoMAPFRESeguros.Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CotizadorAutoMAPFRESeguros.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class CotizadorController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly CotizacionToken cotizacionToken;
        public readonly string urlBase;

        public CotizadorController(IConfiguration configuration, CotizacionToken cotizacionToken)
        {
            this.configuration = configuration;
            this.cotizacionToken = cotizacionToken;
            this.urlBase = configuration["baseUrl"]!;
        }

        [HttpGet("vehicleBrands/{companiaId}/{vehicleTypeCode}")]
        public async Task<ActionResult<List<Catalog>>> vehicleBrands(string companiaId, string vehicleTypeCode)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/vehicleBrands?companyId={companiaId}&vehicleTypeCode={vehicleTypeCode}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }

        [HttpGet("vehicleModels/{companiaId}/{vehicleBrandId}")]
        public async Task<ActionResult<List<Catalog>>> vehicleModels(string companiaId, string vehicleBrandId)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/vehicleModels?companyId={companiaId}&vehicleBrandId={vehicleBrandId}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }

        [HttpGet("vehicleUses/{companiaId}")]
        public async Task<ActionResult<List<Catalog>>> vehicleUses(string companiaId)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/vehicleUses?companyId={companiaId}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }



            return Ok(marcas);
        }

        [HttpGet("gasEquipements")]
        public async Task<ActionResult<List<Catalog>>> gasEquipements()
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/gasEquipements"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }

        [HttpGet("drivingZones")]
        public async Task<ActionResult<List<Catalog>>> drivingZones()
        {
            var marcas = new List<Catalog>();
            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/drivingZones"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }

        [HttpGet("vehicleSubModels/{companiaId}/{vehicleBrandCode}/{vehicleModelCode}")]
        public async Task<ActionResult<List<Catalog>>> vehicleSubModels(string companiaId, string vehicleBrandCode, string vehicleModelCode)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/vehicleSubModels?companyId={companiaId}&vehicleBrandCode={vehicleBrandCode}&vehicleModelCode={vehicleModelCode}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }

        [HttpGet("states")]
        public async Task<ActionResult<List<Catalog>>> states()
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/states?countryCode=RD"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }



            return Ok(marcas);
        }

        [HttpGet("provinces/{countryCode}/{stateCode}")]
        public async Task<ActionResult<List<Catalog>>> provinces(string countryCode, string stateCode)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/provinces?countryCode={countryCode}&stateCode={stateCode}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }



            return Ok(marcas);
        }

        [HttpGet("towns/{countryCode}/{provinceCode}")]
        public async Task<ActionResult<List<Catalog>>> towns(string countryCode, string provinceCode)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/towns?countryCode={countryCode}&provinceCode={provinceCode}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }

        [HttpGet("accesories/{vehicleBrandCode}/{vehicleModelCode}/{vehicleSubModelCode}")]
        public async Task<ActionResult<List<Catalog>>> accesories(string vehicleBrandCode, string vehicleModelCode, string vehicleSubModelCode)
        {
            var marcas = new List<Catalog>();
            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/accesories?vehicleBrandCode={vehicleBrandCode}&vehicleModelCode={vehicleModelCode}&vehicleSubModelCode={vehicleSubModelCode}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }

        [HttpGet("vehicleSubModelYears/{vehicleBrandCode}/{vehicleModelCode}/{vehicleSubModelCode}")]
        public async Task<ActionResult<List<Catalog>>> vehicleSubModelYears(string vehicleBrandCode, string vehicleModelCode, string vehicleSubModelCode)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}catalog/vehicleSubModelYears?companyId=6&vehicleBrandCode={vehicleBrandCode}&vehicleModelCode={vehicleModelCode}&vehicleSubModelCode={vehicleSubModelCode}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    if (datos.Trim() == "")
                    {
                        return await vehicleSubModelYears(vehicleBrandCode, vehicleModelCode, "1");//BadRequest("No existen años para este submodelo");
                    }
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(datos);
                    result.OrderByDescending(p => p.parameterId).ToList();
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }



            return Ok(marcas);
        }

        [HttpPost("SeachInsurabilityScale")]
        public async Task<ActionResult<VehiclePrices>> SeachInsurabilityScale(InsurabilityScaleRequest request)
        {
            VehiclePrices insurabilityScale = new VehiclePrices();
            //Se agrega la moneda por defecto ya que la misma siempre sera en peso.
            request.currencyId = 1;

            try
            {

                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.PostAsJsonAsync($"{urlBase}catalog/searchInsurabilityScale", request))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    if (datos.Trim().Contains("exception") || datos.Trim().Contains("error"))
                    {
                        return BadRequest("No existen precios para este submodelo y año");
                    }
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<VehiclePrices>>(datos);
                    // Se agrega condicion para que devuelva solo el los valores del anio solicitado.
                    var returnValue = result.Find(x => x.vehicleSubModelYearNum == request.vehicleSubModelYearNum);
                    return Ok(returnValue);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("multipleAutoTrebol")]
        public async Task<ActionResult<List<CotizadorResponse>>> multipleAutoTrebol(AutoTrebolRequest request)
        {

            var insurabilityScale = new List<CotizadorResponse>();

            try
            {

                if (request.Owner.identityDocumentNumber != null)
                {
                    request.PolicyHolder.identityDocumentNumber = request.Owner.identityDocumentNumber.Trim().Replace("-","").Replace(" ","");
                    request.PolicyHolder.identityDocumentTypeCode = request.Owner.identityDocumentTypeCode;
                    request.PolicyHolder.name = request.Owner.name;
                    request.PolicyHolder.firstSurname = request.Owner.firstSurname;
                    request.PolicyHolder.phone = request.Owner.phone.Trim().Replace(")", "").Replace("(", "").Replace("-", "");
                    request.PolicyHolder.SecondSurname = request.Owner.SecondSurname;
                    request.PolicyHolder.mobile = request.Owner.mobile.Trim().Replace(")", "").Replace("(", "").Replace("-", "");
                    request.PolicyHolder.email = request.Owner.email;
                }
                var borrame = System.Text.Json.JsonSerializer.Serialize<AutoTrebolRequest>(request);

                cotizacionToken.SetCredentials();
                using (var message = await ApiCaller.Client.PostAsJsonAsync($"{urlBase}project/multipleAutoTrebol", request))
                {

                    var datos = await message.Content.ReadAsStringAsync();

                    if (datos.Trim().Contains("exception") || datos.Trim().Contains("error"))
                    {
                        return BadRequest("No existen precios para este submodelo y año");
                    }
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<CotizadorResponse>>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarNombre/{companiaId}/{identificacion}/{tipoIdentificacion}")]
        public async Task<ActionResult<IdentificacionDTO>> BuscarNombre(string companiaId, string identificacion, string tipoIdentificacion)
        {
            var marcas = new List<Catalog>();

            try
            {
                cotizacionToken.SetCredentials();

                using (var message = await ApiCaller.Client.GetAsync($"{urlBase}client/searchClientByDocuement?companyId={companiaId}&identityDocumentNumber={identificacion}&identityDocumentTypeCode={tipoIdentificacion}"))
                {
                    var datos = await message.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<IdentificacionDTO>(datos);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }

            return Ok(marcas);
        }
    }
}
