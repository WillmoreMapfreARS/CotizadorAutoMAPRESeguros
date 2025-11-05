using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class QuickQuotationResponse
    {
        public string CommercialProductCode { get; set; } = string.Empty;
        public string CommercialProductName { get; set; } = string.Empty;
        public string PlanId { get; set; } = string.Empty;
        public decimal TotGrossAmn { get; set; }
        public List<Coverage> Coverages { get; set; } = new List<Coverage>();
        public List<Division> Division { get; set; } = new List<Division>();
        public List<Financing> Financing { get; set; } = new List<Financing>();

        //public List<QuickQuotationResponse> JsonData(string jsonString)
        //{
           

        //    List<QuickQuotationResponse> responses = JsonConvert.DeserializeObject<List<QuickQuotationResponse>>(jsonString);
        //    return responses;

        //}
    }

    public class Coverage
    {
        public string CoverageId { get; set; } = string.Empty;
        public string CoverageDesc { get; set; } = string.Empty;
        public string LimitName { get; set; } = string.Empty;
        public string SumInsuredAmn { get; set; }  =string.Empty;
    }

    public class Division
    {
        public string PaymentModalityId { get; set; } = string.Empty;
        public string PaymentModalityDesc { get; set; } = string.Empty;
        public decimal InitialPaymentAmn { get; set; }
        public decimal PaymentAmount { get; set; }
    }

    public class Financing
    {
        public string ReceiptId { get; set; } = string.Empty;
        public decimal ReceiptTotAmn { get; set; }
    }
}
