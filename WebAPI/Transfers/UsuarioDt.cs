namespace WebAPI.Transfers
{
    public class UsuarioDt
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contrasennia { get; set; }

        public string nomCompletos()
        {
            return Nombre + " " + Apellido;
        }
    }
}
