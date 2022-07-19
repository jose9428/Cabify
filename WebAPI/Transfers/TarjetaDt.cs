namespace WebAPI.Transfers
{
    public class TarjetaDt
    {
        public int IdTarjeta { get; set; }
        public int IdUsuario { get; set; }
        public string? NumeroTarjeta { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public int? Cvv { get; set; }

    }
}
