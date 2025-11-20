using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class Owner
    {
        public string identityDocumentTypeCode { get; set; } = string.Empty;
        public string identityDocumentNumber { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string firstSurname { get; set; } = string.Empty;
        public string SecondSurname { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string mobile { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public int stateCode { get; set; } = 1;
        //public int provinces { get; set; }
        //public int towns { get; set; }
    }
}
