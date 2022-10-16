using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinStatus.Shared
{
    public class Förbrukning
    {
        public int FörbrukningId { get; set; }
        public int LeverantörId { get; set; }
        public Leverantör? Leverantör { get; set; }
        public int KvantitetVial { get; set; }
        public DateTime Förburkningsdatum { get; set; }
        public DateTime RegistreradDatum { get; set; } = DateTime.Now;
        public string RegistreradAv { get; set; }
        public Vårdgivare? Vårdgivare { get; set; }
        public int VårdgivareId { get; set; }
    }
}