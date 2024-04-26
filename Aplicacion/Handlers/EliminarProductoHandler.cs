using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class EliminarProductoHandler : IRequestHandler<EliminarProductoRequest, EliminarProductoResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia ProductoDao
        /// </summary>
        private readonly ProductoDao _productoDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public EliminarProductoHandler(ProductoDao productoDao)
        {
            this._productoDao = productoDao;
        }

        #endregion inyeccion de dependencias

        public async Task<EliminarProductoResponse> Handle(EliminarProductoRequest request, CancellationToken cancellation)
        {
            await _productoDao.EliminarProducto(request.IdProducto);
            return new EliminarProductoResponse();
        }
    }
}
