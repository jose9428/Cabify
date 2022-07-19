using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Transfers;

namespace WebAPI.Services
{
    public partial class UsuarioSOA
    {
        public static UsuarioDt Autentificar(string correo, string password)
        {
            bdCabifyContext db = new bdCabifyContext();
            UsuarioDt user = (from u in db.Usuarios
                              where u.Correo.Equals(correo) && u.Contrasennia.Equals(password)
                              select new UsuarioDt()
                              {
                                  IdUsuario = u.IdUsuario,
                                  Correo = u.Correo,
                                  Apellido = u.Apellido,
                                  Nombre = u.Nombre,
                                  Contrasennia = u.Contrasennia
                              }).FirstOrDefault();
            return user;
        }

        public static ApiResponse RegistrarCuenta(Usuario obj)
        {
            ApiResponse apiResonse = new ApiResponse();
            bdCabifyContext db = new bdCabifyContext();

            int valCorreo = db.Usuarios.Where(x => x.Correo == obj.Correo).Count();

            if (valCorreo == 0)
            {
                db.Usuarios.Add(obj);

                if (db.SaveChanges() == 0)
                {
                    apiResonse.msj = "No se pudo crear cuenta";
                    apiResonse.estatus = 500;
                }
                else
                {
                    apiResonse.data = obj;
                }
            }
            else
            {
                apiResonse.msj = "El correo "+obj.Correo+" ya se encuentra en uso";
                apiResonse.estatus = 500;
            }

            return apiResonse;
        }

        public static ApiResponse EditarCuenta(UsuarioDt obj)
        {
            ApiResponse apiResonse = new ApiResponse();
            bdCabifyContext db = new bdCabifyContext();

            Usuario user = db.Usuarios.Find(obj.IdUsuario);

            if (user != null)
            {
                user.Apellido = obj.Apellido;
                user.Nombre = obj.Nombre;
                user.Contrasennia = obj.Contrasennia;

                db.Entry(user).State = EntityState.Modified;
                if (db.SaveChanges() == 0)
                {
                    apiResonse.msj = "No se pudo editar cuenta";
                    apiResonse.estatus = 500;
                }
                else
                {
                    apiResonse.data = obj;
                }
            }
            else
            {
                apiResonse.msj = "Usuario no encontrado";
                apiResonse.estatus = 404;
            }

            return apiResonse;
        }
    }
}
