using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class AutoTrebolResponse
    {
        public string projectQuoteId { get; set; }  = string.Empty;
        public string endorsementNumber { get; set; }   = string.Empty;
        public DateTime effectiveDate { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime captureDate { get; set; }
        public bool policyRetainedInd { get; set; }
        public PremiumDetail premiumDetail { get; set; }= new PremiumDetail();
    }
}
