using Dominio.DTOs;
using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class ConsultarTodosProductosHandler : IRequestHandler<ConsultarTodosProductosRequest, ConsultarTodosProductosResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia ProductoDao
        /// </summary>
        private readonly ProductoDao _productoDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public ConsultarTodosProductosHandler(ProductoDao productoDao)
        {
            this._productoDao = productoDao;
        }

        #endregion inyeccion de dependencias

        public async Task<ConsultarTodosProductosResponse> Handle(ConsultarTodosProductosRequest request, CancellationToken cancellation)
        {
            List<InformacionConsultaProductoDTO> listado = await _productoDao.ConsultarTodosProductos();
            ConsultarTodosProductosResponse respuesta = new ConsultarTodosProductosResponse();
            respuesta.ListadoProductos = listado;
            return respuesta;
        }
    }
}
