using Dominio.Response;
using MediatR;

namespace Dominio.Request
{
    public class ConsultarPorIdRegistroAlmacenRequest : IRequest<ConsultarPorIdRegistroAlmacenResponse>
    {
        public int IdRegistro { get; set; }
    }
}
