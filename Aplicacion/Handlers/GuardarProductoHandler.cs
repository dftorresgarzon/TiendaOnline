using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class GuardarProductoHandler : IRequestHandler<GuardarProductoRequest, GuardarProductoResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia ProductoDao
        /// </summary>
        private readonly ProductoDao _productoDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public GuardarProductoHandler(ProductoDao productoDao)
        {
            this._productoDao = productoDao;
        }

        #endregion inyeccion de dependencias

        public async Task<GuardarProductoResponse> Handle(GuardarProductoRequest request, CancellationToken cancellation)
        {
            await _productoDao.GuardarProducto(request.InformacionProducto);
            return new GuardarProductoResponse();
        }
    }
}
