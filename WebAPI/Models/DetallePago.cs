using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class DetallePago
    {
        public int IdDetPago { get; set; }
        public int? IdPago { get; set; }
        public string? NomChofer { get; set; }
        public string? Placa { get; set; }
        public string? NumeroTarjeta { get; set; }

        public virtual Pago? IdPagoNavigation { get; set; }
    }
}
