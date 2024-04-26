using Dominio.Request;
using Dominio.Response;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlmacenController : Controller
    {
        /// <summary>
        /// Mediador de llamados
        /// </summary>
        private readonly IMediator mediator2;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mediator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AlmacenController(IMediator mediator2)
        {
            this.mediator2 = (mediator2 != null ? mediator2 : throw new ArgumentNullException(nameof(mediator2)));
        }

        /// <summary>
        /// Método ConsultarTodosRegistrosAlmacen
        /// </summary>
        [HttpPost]
        public Task<ConsultarTodosRegistrosAlmacenResponse> ConsultarTodosRegistrosAlmacen([FromBody] ConsultarTodosRegistrosAlmacenRequest request, CancellationToken cancellationToken)
        {
            return this.mediator2.Send(request, cancellationToken);
        }

        /// <summary>
        /// Método ConsultarPorIdRegistroAlmacen
        /// </summary>
        [HttpPost]
        public Task<ConsultarPorIdRegistroAlmacenResponse> ConsultarPorIdRegistroAlmacen([FromBody] ConsultarPorIdRegistroAlmacenRequest request, CancellationToken cancellationToken)
        {
            return this.mediator2.Send(request, cancellationToken);
        }

        /// <summary>
        /// Método ModificarRegistroAlmacen
        /// </summary>
        [HttpPost]
        public Task<ModificarRegistroAlmacenResponse> ModificarRegistroAlmacen([FromBody] ModificarRegistroAlmacenRequest request, CancellationToken cancellationToken)
        {
            return this.mediator2.Send(request, cancellationToken);
        }

    }
}
