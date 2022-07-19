using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            Pagos = new HashSet<Pago>();
        }

        public int IdTipoPago { get; set; }
        public string NomTipo { get; set; } = null!;

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
