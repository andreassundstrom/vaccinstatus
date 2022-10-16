using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinStatus.Shared
{
    public class Kapacitet
    {
        public int KapacitetId { get; set; }
        public DateTime Kapacitetsdatum { get; set; }
        public int KapacitetDoser { get; set; }
        public Vårdgivare? Vårdgivare { get; set; }
        public int VårdgivareId { get; set; }
    }
}
