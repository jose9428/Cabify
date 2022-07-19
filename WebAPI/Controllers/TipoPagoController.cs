using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoController : ControllerBase
    {
        [HttpGet]
        [Route("todos")]
        public List<TipoPago> ListarMetodosPagos()
        {
            return TipoPagoSOA.ListarMetodosPagos();
        }
    }
}
