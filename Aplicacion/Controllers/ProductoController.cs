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
    public class ProductoController : Controller
    {
        /// <summary>
        /// Mediador de llamados
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mediator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProductoController(IMediator mediator)
        {
            this.mediator = (mediator != null ? mediator : throw new ArgumentNullException(nameof(mediator)));
        }

        /// <summary>
        /// Método ConsultarTodosProductos
        /// </summary>
        [HttpPost]
        public Task<ConsultarTodosProductosResponse> ConsultarTodosProductos([FromBody] ConsultarTodosProductosRequest request, CancellationToken cancellationToken)
        {
            return this.mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Método ConsultarPorIdProducto
        /// </summary>
        [HttpPost]
        public Task<ConsultarPorIdProductoResponse> ConsultarPorIdProducto([FromBody] ConsultarPorIdProductoRequest request, CancellationToken cancellationToken)
        {
            return this.mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Método GuardarProducto
        /// </summary>
        [HttpPost]
        public Task<GuardarProductoResponse> GuardarProducto([FromBody] GuardarProductoRequest request, CancellationToken cancellationToken)
        {
            return this.mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Método ModificarProducto
        /// </summary>
        [HttpPost]
        public Task<ModificarProductoResponse> ModificarProducto([FromBody] ModificarProductoRequest request, CancellationToken cancellationToken)
        {
            return this.mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Método EliminarProducto
        /// </summary>
        [HttpPost]
        public Task<EliminarProductoResponse> EliminarProducto([FromBody] EliminarProductoRequest request, CancellationToken cancellationToken)
        {
            return this.mediator.Send(request, cancellationToken);
        }
    }
}
