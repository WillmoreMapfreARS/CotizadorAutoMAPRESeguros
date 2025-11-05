using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class CotizadorPlanes
    {
        public string NombrePlan { get; set; }= string.Empty;
        public double PrecioPlan { get; set; }
        public string IdCotizacion { get; set; } = string.Empty;
        public List< CuotasPlan> Cuotas { get; set; } = new List< CuotasPlan>();
        public string Deducible { get; set; } = string.Empty;
        public string AutoRentado { get; set; } = string.Empty;
        public string ResponsbilidadCivil { get; set; } = string.Empty;
        public string AccidentesConductor { get; set; } = string.Empty;
        public string FianzaJudicial { get; set; } = string.Empty;
        public string CentroAcistenciaAutomovilista { get; set; } = string.Empty;
        public string AsistenciaMAPFREBHD { get; set; } = string.Empty;
        public string Depreciacion { get; set; } = string.Empty;
        public string DañosPorPavimento { get; set; } = string.Empty;
        public string DañosPorAgua { get; set; } = string.Empty;
        public string RobosPartesExternas { get; set; } = string.Empty;

        public List<Coverage> Coverages { get; set; } = new List<Coverage>();

    }
    public class CuotasPlan
    {
        public string descripcion { get; set; } = string.Empty;
        public int valor { get; set; } 
    }
}
