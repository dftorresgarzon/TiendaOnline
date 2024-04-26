namespace Dominio.DTOs
{
    public class InformacionConsultaRegistroAlmacenDTO
    {
        public int IdRegistro { get; set; }
        public string NombreSucursal { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
