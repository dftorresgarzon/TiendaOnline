using Dominio.Entities;
using Dominio.Response;
using MediatR;

namespace Dominio.Request
{
    public class ModificarProductoRequest : IRequest<ModificarProductoResponse>
    {
        public Producto InformacionProducto { get; set; }

    }
}
