using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinStatus.Shared
{
    public class Inleverans
    {
        public int InleveransId { get; set; }
        public DateTime? PlaneratLeveransdatum { get; set; }
        public DateTime? Leveransdatum { get; set; }
        public bool? Levererad { get; set; }
        public int LeverantörId { get; set; }
        public int KvantitetVial { get; set; }
        public string GlnMottagare { get; set; }
        public Vårdgivare? Vårdgivare { get; set; }
        public int VårdgivareId { get; set; }

    }
}
