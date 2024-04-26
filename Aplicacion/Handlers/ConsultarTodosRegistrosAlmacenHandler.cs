using Dominio.DTOs;
using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class ConsultarTodosRegistrosAlmacenHandler : IRequestHandler<ConsultarTodosRegistrosAlmacenRequest, ConsultarTodosRegistrosAlmacenResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia AlmacenDao
        /// </summary>
        private readonly AlmacenDao _almacenDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public ConsultarTodosRegistrosAlmacenHandler(AlmacenDao almacenDao)
        {
            this._almacenDao = almacenDao;
        }

        #endregion inyeccion de dependencias

        public async Task<ConsultarTodosRegistrosAlmacenResponse> Handle(ConsultarTodosRegistrosAlmacenRequest request, CancellationToken cancellation)
        {
            List<InformacionConsultaRegistroAlmacenDTO> listado = await _almacenDao.ConsultarTodosRegistrosAlmacen();
            ConsultarTodosRegistrosAlmacenResponse respuesta = new ConsultarTodosRegistrosAlmacenResponse();
            respuesta.ListadoRegistrosAlmacen = listado;
            return respuesta;
        }
    }
}
