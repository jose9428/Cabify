using WebAPI.Models;

namespace WebAPI.Transfers
{
    public class PagoDt
    {
        public int IdPago { get; set; }
        public decimal? Monto { get; set; }
        public int? IdTipoPago { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaPago { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarjeta { get; set; }
        public string ?NumeroTarjeta { get; set; }

        public DetallePagoDt ?detalle { get; set; }
        public UsuarioDt ?usuario { get; set; }
    }
}
