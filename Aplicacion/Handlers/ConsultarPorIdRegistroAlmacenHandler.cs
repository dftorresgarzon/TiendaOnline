using Dominio.DTOs;
using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class ConsultarPorIdRegistroAlmacenHandler : IRequestHandler<ConsultarPorIdRegistroAlmacenRequest, ConsultarPorIdRegistroAlmacenResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia AlmacenDao
        /// </summary>
        private readonly AlmacenDao _almacenDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public ConsultarPorIdRegistroAlmacenHandler(AlmacenDao almacenDao)
        {
            this._almacenDao = almacenDao;
        }

        #endregion inyeccion de dependencias

        public async Task<ConsultarPorIdRegistroAlmacenResponse> Handle(ConsultarPorIdRegistroAlmacenRequest request, CancellationToken cancellation)
        {
            InformacionConsultaRegistroAlmacenDTO datosRegistroAlmacen = await _almacenDao.ConsultarPorIdRegistroAlmacen(request.IdRegistro);
            ConsultarPorIdRegistroAlmacenResponse respuesta = new ConsultarPorIdRegistroAlmacenResponse();
            if (datosRegistroAlmacen.IdRegistro != 0)
            {
                respuesta.RegistroAlmacen = datosRegistroAlmacen;
                return respuesta;
            }
            else
            {
                throw new InvalidOperationException("no existe informacion con ese numero");
            }
        }
    }
}
