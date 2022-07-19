using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Transfers;

namespace WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        [HttpPost]
        [Route("realizar")]
        public ApiResponse RealizarPago(PagoDt obj)
        {
            return PagoSOA.RealizarPago(obj);
        }

        [HttpGet]
        [Route("detalle")]
        public ApiResponse DetalleComprobante(int idPago)
        {
            return PagoSOA.DetalleComprobante(idPago);
        }

        [HttpGet]
        [Route("correo")]
        public ApiResponse EnviarComprobante(int idPago)
        {
            return PagoSOA.EnviarComprobante(idPago);
        }
    }
}
