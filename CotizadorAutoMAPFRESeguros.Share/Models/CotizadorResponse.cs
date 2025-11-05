using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class CotizadorResponse
    {
        public string commercialProductCode { get; set; } =string.Empty;
        public string commercialProductName { get; set; } = string.Empty;
        public QuotationData QuotationData { get; set; }= new QuotationData();
        public List<Coverage> Coverages { get; set; } = new List<Coverage>();
    }

  

  
}
