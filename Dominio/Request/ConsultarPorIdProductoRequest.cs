using Dominio.Response;
using MediatR;

namespace Dominio.Request
{
    public class ConsultarPorIdProductoRequest : IRequest<ConsultarPorIdProductoResponse>
    {
        public int IdProducto { get; set; }
    }
}
