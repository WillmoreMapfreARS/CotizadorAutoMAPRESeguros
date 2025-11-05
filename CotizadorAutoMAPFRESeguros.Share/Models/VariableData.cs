using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class VariableData
    {
        public string autoAssistanceCompany { get; set; } ="1";
        public int commercialProductCode { get; set; } = 3000;
        public int drivingZone { get; set; }
        public int gasEquipment { get; set; }
        public string haitiDriving { get; set; } = "N";
        public int vehicleBrandCode { get; set; }
        public int vehicleModelCode { get; set; }
        public int vehicleSubModelCode { get; set; }
        public int vehicleSubModelYearNum { get; set; } = 99;
        public int vehicleUseCode { get; set; } = 1;
        public decimal vehicleValue { get; set; }
        public string? chassisNumber { get; set; } 
        //public string? vehiclePlateNumber { get; set; } 

    }
}
