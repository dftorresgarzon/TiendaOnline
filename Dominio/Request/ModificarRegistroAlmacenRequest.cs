using Dominio.Entities;
using Dominio.Response;
using MediatR;

namespace Dominio.Request
{
    public class ModificarRegistroAlmacenRequest : IRequest<ModificarRegistroAlmacenResponse>
    {
        public RegistroAlmacen InformacionRegistroAlmacen { get; set; }

    }
}
