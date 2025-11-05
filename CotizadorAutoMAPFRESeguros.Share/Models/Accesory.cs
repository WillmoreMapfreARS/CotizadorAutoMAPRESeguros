using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class Accesory
    {
        public int accesoryCode { get; set; }
        public string accesoryName { get; set; } = string.Empty;
        public decimal accesoryValue { get; set; }
    }
}
