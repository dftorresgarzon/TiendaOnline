namespace Dominio.DTOs
{
    public class InformacionConsultaProductoDTO
    {
        public int IdProducto { get; set; }
        public string NombreFabricante { get; set; }
        public string Forma { get; set; }
        public string NombreProducto { get; set; }
        public int TamanioCm3 { get; set; }
        public decimal Precio { get; set; }
        public int IdSubdepartamento { get; set; }
        public string UrlImagen { get; set; }

    }
}
