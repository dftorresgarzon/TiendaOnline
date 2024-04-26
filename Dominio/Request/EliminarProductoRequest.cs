using Dominio.Response;
using MediatR;

namespace Dominio.Request
{
    public class EliminarProductoRequest : IRequest<EliminarProductoResponse>
    {
        public int IdProducto { get; set; }
    }
}
