using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Transfers;

namespace WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        [HttpPost]
        [Route("asociar")]
        public ApiResponse AsociarTarjeta(TarjetaDt objTarj)
        {
            Tarjetum obj = new Tarjetum
            {
                IdUsuario = objTarj.IdUsuario,
                Cvv= objTarj.Cvv,
                FechaCaducidad = objTarj.FechaCaducidad,
                NumeroTarjeta = objTarj.NumeroTarjeta
            };

            return TarjetaSOA.RegistrarTarjeta(obj);
        }
    }
}
