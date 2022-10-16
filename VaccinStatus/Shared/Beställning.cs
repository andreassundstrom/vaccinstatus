using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinStatus.Shared
{
    public class Beställning
    {
        public int BeställningId { get; set; }
        public DateTime Beställningsdatum { get; set; }
        public DateTime ÖnskatLeveransdatum { get; set; }
        public int KvantitetDos { get; set; }
        public string GlnMottagare { get; set; }
        public Vårdgivare? Vårdgivare { get; set; }
        public int VårdgivareId { get; set; }

    }
}
