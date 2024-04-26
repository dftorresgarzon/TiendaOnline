using Dominio.DTOs;
using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class ConsultarPorIdProductoHandler : IRequestHandler<ConsultarPorIdProductoRequest, ConsultarPorIdProductoResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia ProductoDao
        /// </summary>
        private readonly ProductoDao _productoDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public ConsultarPorIdProductoHandler(ProductoDao productoDao)
        {
            this._productoDao = productoDao;
        }

        #endregion inyeccion de dependencias

        public async Task<ConsultarPorIdProductoResponse> Handle(ConsultarPorIdProductoRequest request, CancellationToken cancellation)
        {
            InformacionConsultaProductoDTO datosProducto = await _productoDao.ConsultarPorIdProducto(request.IdProducto);
            ConsultarPorIdProductoResponse respuesta = new ConsultarPorIdProductoResponse();
            if (datosProducto.IdProducto != 0)
            {
                respuesta.Producto = datosProducto;
                return respuesta;
            }
            else
            {
                throw new InvalidOperationException("no existe informacion con ese numero");
            }
        }
    }
}
