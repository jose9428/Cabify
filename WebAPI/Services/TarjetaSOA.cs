using WebAPI.Models;
using WebAPI.Transfers;

namespace WebAPI.Services
{
    public partial class TarjetaSOA
    {
        public static ApiResponse RegistrarTarjeta(Tarjetum obj)
        {
            ApiResponse apiResonse = new ApiResponse();
            bdCabifyContext db = new bdCabifyContext();

            Usuario user = db.Usuarios.Find(obj.IdUsuario);

            if (user != null)
            {
                Tarjetum objTar = db.Tarjeta.Where(x => x.NumeroTarjeta == obj.NumeroTarjeta).FirstOrDefault();

                if (objTar==null)
                {
                    db.Tarjeta.Add(obj);

                    if (db.SaveChanges() == 0)
                    {
                        apiResonse.msj = "No se pudo asociar tarjeta";
                        apiResonse.estatus = 500;
                    }
                    else
                    {
                        apiResonse.data = obj;
                    }
                }
                else
                {
                    apiResonse.msj = "El numero de tarjeta "+obj.NumeroTarjeta+" ya se encuentra registrado.";
                    apiResonse.estatus = 404;
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
