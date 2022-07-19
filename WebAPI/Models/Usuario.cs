using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pagos = new HashSet<Pago>();
            Tarjeta = new HashSet<Tarjetum>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contrasennia { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Tarjetum> Tarjeta { get; set; }
    }
}
