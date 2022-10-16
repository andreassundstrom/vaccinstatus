using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinStatus.Shared.Statistik
{
    public class Rapporteringsöversikt
    {
        public int VårdgivareId { get; set; }
        public string Vårdgivare { get; set; }
        public int Beställning { get; set; }
        public int Förbrukning { get; set; } 
        public int Inleverans { get; set; }
        public int Kapacitet { get; set; }
        public int Lagersaldo { get; set; }
    }
}
