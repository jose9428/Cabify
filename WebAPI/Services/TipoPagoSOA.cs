using WebAPI.Models;

namespace WebAPI.Services
{
    public partial class TipoPagoSOA
    {
        public static List<TipoPago> ListarMetodosPagos()
        {
            bdCabifyContext db = new bdCabifyContext();
            return db.TipoPagos.ToList();
        }
    }
}
