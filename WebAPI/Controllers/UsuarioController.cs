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
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Autentificar(UsuarioDt objUser)
        {

            UsuarioDt obj = UsuarioSOA.Autentificar(objUser.Correo, objUser.Contrasennia);
            if (obj != null)
                return Ok(obj);
            else
                return NotFound("Usuario no encontrado");
        }
        [HttpPost]
        [Route("crear")]
        public ApiResponse CrearCuenta(Usuario objUser)
        {
            return UsuarioSOA.RegistrarCuenta(objUser);
        }

        [HttpPut]
        [Route("editar")]
        public ApiResponse EditarCuenta(UsuarioDt objUser)
        {
            return UsuarioSOA.EditarCuenta(objUser);
        }
    }
}
