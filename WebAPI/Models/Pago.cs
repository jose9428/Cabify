using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Pago
    {
        public Pago()
        {
            DetallePagos = new HashSet<DetallePago>();
        }

        public int IdPago { get; set; }
        public decimal? Monto { get; set; }
        public int? IdTipoPago { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaPago { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarjeta { get; set; }

        public virtual Tarjetum IdTarjetaNavigation { get; set; } = null!;
        public virtual TipoPago? IdTipoPagoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<DetallePago> DetallePagos { get; set; }
    }
}
