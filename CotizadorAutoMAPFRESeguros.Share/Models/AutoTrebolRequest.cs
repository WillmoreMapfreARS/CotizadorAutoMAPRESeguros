using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class AutoTrebolRequest
    {
        public PolicyHolder PolicyHolder { get; set; } = new PolicyHolder();
        public Owner Owner { get; set; } =new Owner();
        public List<Accesory> Accesories { get; set; }= new List<Accesory>();
        public Coverages Coverages { get; set; } = new Coverages();
        public FixedData FixedData { get; set; } = new FixedData();
        public VariableData VariableData { get; set; } = new VariableData();
    }
}
