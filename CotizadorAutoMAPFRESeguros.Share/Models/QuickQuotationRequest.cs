using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class QuickQuotationRequest
    {
        public string AccesoryValue { get; set; } = string.Empty;

        public string AutoAssistanceCompany { get; set; } = string.Empty;

        public string CurrencyId { get; set; } = string.Empty;

        public string DrivingZone { get; set; } = string.Empty;

        public string HaitiDriving { get; set; } = string.Empty;

        public string VehicleBrandCode { get; set; } = string.Empty;

        public string VehicleModelCode { get; set; } = string.Empty;

        public string VehicleSubModelCode { get; set; } = "99";

        public string VehicleSubModelYearNum { get; set; } = string.Empty;

        public string VehicleTypeCode { get; set; } = string.Empty;

        public string VehicleUseCode { get; set; } = string.Empty;

        public string VehicleValue { get; set; } = string.Empty;
    }

}
