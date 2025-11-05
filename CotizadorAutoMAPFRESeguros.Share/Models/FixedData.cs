using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class FixedData
    {
        public string currencyId { get; set; } = "1";
        public string dueDate { get; set; } = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
        public string effectiveDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
    }
}
