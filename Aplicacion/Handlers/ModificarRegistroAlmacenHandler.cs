using Dominio.Request;
using Dominio.Response;
using Infraestructura.Dao;
using MediatR;

namespace Aplicacion.Handlers
{
    public class ModificarRegistroAlmacenHandler : IRequestHandler<ModificarRegistroAlmacenRequest, ModificarRegistroAlmacenResponse>
    {
        #region inyeccion de dependencias

        /// <summary>
        /// Instancia AlmacenDao
        /// </summary>
        private readonly AlmacenDao _almacenDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public ModificarRegistroAlmacenHandler(AlmacenDao almacenDao)
        {
            this._almacenDao = almacenDao;
        }

        #endregion inyeccion de dependencias

        public async Task<ModificarRegistroAlmacenResponse> Handle(ModificarRegistroAlmacenRequest request, CancellationToken cancellation)
        {
            await _almacenDao.ModificarRegistroAlmacen(request.InformacionRegistroAlmacen);
            return new ModificarRegistroAlmacenResponse();
        }
    }
}
