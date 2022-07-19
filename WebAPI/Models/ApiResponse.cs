namespace WebAPI.Models
{
    public class ApiResponse
    {
        public int estatus { get; set; }
        public string msj { get; set; }
        public object data { get; set; }

        public ApiResponse()
        {
            this.estatus = 200;
            this.msj = "OK";
            this.data = null;   
        }
    }
}
