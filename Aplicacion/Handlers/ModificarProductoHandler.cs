using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class ModificarProductoHandler : IRequestHandler<ModificarProductoRequest, ModificarProductoResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia ProductoDao
        /// </summary>
        private readonly ProductoDao _productoDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public ModificarProductoHandler(ProductoDao productoDao)
        {
            this._productoDao = productoDao;
        }

        #endregion inyeccion de dependencias

        public async Task<ModificarProductoResponse> Handle(ModificarProductoRequest request, CancellationToken cancellation)
        {
            await _productoDao.ModificarProducto(request.InformacionProducto);
            return new ModificarProductoResponse();
        }
    }
}
