using System.Net;
using System.Net.Mail;
using WebAPI.Models;

namespace WebAPI.Transfers
{
    public class CorreoDt
    {
         const string fromRemitente = "recuperarUTP@gmail.com";
         const string fromPassword = "yllhxwcjdnsaqplx";

        public string EnviarCorreo(string correo, PagoDt obj)
        {
            string msg = "";
            try
            {
                var fromAddress = new MailAddress(fromRemitente, "Cabify");
                var toAddress = new MailAddress(correo, "Detalle Comprobante");

                const string subject = "Comprobante";

                string body = CuerpoComprobante(obj);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body
                })
                {
                    smtp.Send(message);

                    msg = "Mensaje Enviado Correctamente!!";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        public string CuerpoComprobante(PagoDt obj)
        {
            string body = "<!DOCTYPE html>\n"
                    + "<html>\n"
                    + "<head>\n"
                    + "<style>\n"
                    + " table { width: 80%;border: 1px solid #666666;}"
                    + "th, td {  text-align: left; padding: 8px;border: 1px solid #666666;}\n"
                    + "tr:nth-child(even){background-color: #f2f2f2}"
                    + "th { background-color: #4CAF50;color: white;}"
                    + "</style>\n"
                    + "</head>\n"
                    + "<body>\n"
                    + "<span>Hola!! <strong>" + obj.usuario.nomCompletos() + "</strong></span> <br> <br>"
                    + "<span>Le enviamos el comprobante de pago por la reserva de vehiculo.</span>\n"
                    + " <br><br>"
                    + " <table>"
                    + "<tr><th>Numero Comprobante Pago: </th><td>" + obj.IdPago + "</td></tr>"
                    + "<tr><th>Numero Tarjeta Pago: </th><td>" + obj.detalle.NumeroTarjeta + "</td></tr>"
                    + "<tr><th>Chofer</th><td>" + obj.detalle.NomChofer + "</td></tr>"
                    + "<tr><th>Nro Placa</th><td>" + obj.detalle.Placa + "</td></tr>"
                    + "<tr><th>Fecha</th><td>" + obj.FechaPago + " </td></tr>"
                    + "<tr><th>Monto (S/.)</th><td>" + obj.Monto + " </td></tr>"
                    + "</table>"
                    + " <br>"
                    + "<strong>Gracias.</strong>"
                    + "</body>\n"
                    + "</html>";
            return body;
        }
    }
}
