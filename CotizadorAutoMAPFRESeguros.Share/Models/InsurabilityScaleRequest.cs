using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class InsurabilityScaleRequest
    {
        public int currencyId { get; set; } = 1;
        public int vehicleBrandCode { get; set; }
        public int vehicleModelCode { get; set; }
        public int vehicleSubModelCode { get; set; }
        public int vehicleSubModelYearNum { get; set; }
    }

}
