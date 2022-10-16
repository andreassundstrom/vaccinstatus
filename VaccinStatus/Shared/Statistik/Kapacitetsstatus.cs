using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinStatus.Shared.Statistik
{
    public class Kapacitetsstatus
    {
        public int VårdgivareId { get; set; }
        public string Vårdgivare { get; set; }
        public int? KapacitetDoser { get; set; }
        public DateTime? Kapacitetsdatum { get; set; }
    }
}
