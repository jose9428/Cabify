using WebAPI.Models;
using WebAPI.Transfers;

namespace WebAPI.Services
{
    public partial class PagoSOA
    {
        public static ApiResponse RealizarPago(PagoDt obj)
        {
            ApiResponse apiResonse = new ApiResponse();
            bdCabifyContext db = new bdCabifyContext();

            try
            {
                Usuario user = db.Usuarios.Find(obj.IdUsuario);
                //     Tarjetum tarjeta = db.Tarjeta.Find(obj.IdTarjeta);
                Tarjetum tarjeta = db.Tarjeta.Where(x => x.IdUsuario == obj.IdUsuario && x.NumeroTarjeta == obj.NumeroTarjeta).FirstOrDefault<Tarjetum>();

                TipoPago tipoPago = db.TipoPagos.Find(obj.IdTipoPago);

                if (user != null)
                {
                    if (tarjeta != null)
                    {
                        if (tipoPago != null)
                        {
                            Pago objPag = new Pago
                            {
                                IdTarjeta = tarjeta.IdTarjeta,
                                IdUsuario = obj.IdUsuario,
                                IdTipoPago = obj.IdTipoPago,
                                Monto = obj.Monto,
                                FechaPago = DateTime.Now,
                                Descripcion = obj.Descripcion,
                            };
                            db.Pagos.Add(objPag);

                            if (db.SaveChanges() == 0)
                            {
                                apiResonse.msj = "No se pudo efectuar pago";
                                apiResonse.estatus = 500;
                            }
                            else
                            {
                                DetallePago detPag = new DetallePago()
                                {
                                    IdPago = objPag.IdPago,
                                    NomChofer = obj.detalle.NomChofer,
                                    Placa = obj.detalle.Placa,
                                    NumeroTarjeta = obj.NumeroTarjeta 
                                };
                                db.DetallePagos.Add(detPag);
                                db.SaveChanges();
                                apiResonse.data = objPag;
                            }
                        }
                        else
                        {
                            apiResonse.msj = "Tipo de pago no encontrado";
                            apiResonse.estatus = 404;
                        }
                    }
                    else
                    {
                        apiResonse.msj = "Nro de cuenta no encontrada asociada al usuario "+ user.Nombre+" "+user.Apellido;
                        apiResonse.estatus = 404;
                    }
                }
                else
                {
                    apiResonse.msj = "Usuario no encontrado";
                    apiResonse.estatus = 404;
                }

            }
            catch (Exception ex)
            {
                apiResonse.msj = ex.Message;
                apiResonse.estatus = 500;
            }

            return apiResonse;
        }

        public static ApiResponse DetalleComprobante(int idPago)
        {
            ApiResponse apiResonse = new ApiResponse();
            bdCabifyContext db = new bdCabifyContext();

            Pago obj = db.Pagos.Find(idPago);

            if (obj != null)
            {
                DetallePago objDet = db.DetallePagos.Where(x => x.IdPago == obj.IdPago).FirstOrDefault();
                obj.DetallePagos.Add(objDet);
                apiResonse.data = obj;
            }
            else
            {
                apiResonse.estatus = 404;
                apiResonse.msj = "No se encontro comprobante de pago con el id " + idPago;
            }

            return apiResonse;
        }


        public static ApiResponse EnviarComprobante(int idPago)
        {
            ApiResponse apiResonse = new ApiResponse();
            bdCabifyContext db = new bdCabifyContext();

            Pago obj = db.Pagos.Find(idPago);

            if (obj != null)
            {
                DetallePago objDet = db.DetallePagos.Where(x => x.IdPago == obj.IdPago).FirstOrDefault();
                Usuario objUser = db.Usuarios.Where(x => x.IdUsuario == obj.IdUsuario).FirstOrDefault();

                PagoDt pg = new PagoDt()
                {
                    IdPago = obj.IdPago,
                    Descripcion = obj.Descripcion,
                    Monto = obj.Monto,
                    FechaPago = obj.FechaPago,
                    usuario = new UsuarioDt()
                    {
                        Nombre = objUser.Nombre,
                        Apellido = objUser.Apellido
                    },
                    detalle = new DetallePagoDt()
                    {
                        NomChofer = objDet.NomChofer,
                        Placa = objDet.Placa,
                        NumeroTarjeta= objDet.NumeroTarjeta
                    }
                };

                CorreoDt objCorreo = new CorreoDt();
                apiResonse.msj = objCorreo.EnviarCorreo(objUser.Correo, pg);
            }
            else
            {
                apiResonse.estatus = 404;
                apiResonse.msj = "No se encontro comprobante de pago con el id " + idPago;
            }

            return apiResonse;
        }
    }
}
