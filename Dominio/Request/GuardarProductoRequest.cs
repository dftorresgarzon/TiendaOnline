using Dominio.Entities;
using Dominio.Response;
using MediatR;

namespace Dominio.Request
{
    public class GuardarProductoRequest : IRequest<GuardarProductoResponse>
    {
        public Producto InformacionProducto { get; set; }
    }
}
