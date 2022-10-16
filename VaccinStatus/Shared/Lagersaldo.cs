using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinStatus.Shared
{
    public class Lagersaldo
    {
        public int LagersaldoId { get; set; }
        public DateTime Datum { get; set; }
        public int LeverantörId { get; set; }
        public Leverantör? Leverantör { get; set; }
        public int KvantitetVial { get; set; }
        public int KvantitetDos { get; set; }
        public Vårdgivare? Vårdgivare { get; set; }
        public int VårdgivareId { get; set; }
    }
}