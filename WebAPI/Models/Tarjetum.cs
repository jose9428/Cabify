using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Tarjetum
    {
        public Tarjetum()
        {
            Pagos = new HashSet<Pago>();
        }

        public int IdTarjeta { get; set; }
        public int IdUsuario { get; set; }
        public string? NumeroTarjeta { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public int? Cvv { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
