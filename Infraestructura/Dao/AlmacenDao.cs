using Dominio.DTOs;
using Dominio.Entities;
using Infraestructura.Providers;
using System.Data.SqlClient;

namespace Infraestructura.Dao
{
    public class AlmacenDao
    {
        /// <summary>
        /// Obtiene la instancia Singleton de ConexionDb
        /// </summary>
        ConexionDb ConexionDbInstance = ConexionDb.GetInstance();

        /// <summary>
        /// ConsultarTodosRegistrosAlmacen
        /// </summary>
        /// <returns></returns>
        public async Task<List<InformacionConsultaRegistroAlmacenDTO>> ConsultarTodosRegistrosAlmacen()
        {
            List<InformacionConsultaRegistroAlmacenDTO> lista = new List<InformacionConsultaRegistroAlmacenDTO>();
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("ConsultarTodosRegistrosAlmacen", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = await comando.ExecuteReaderAsync();
                comando.Dispose();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        InformacionConsultaRegistroAlmacenDTO entidad = new InformacionConsultaRegistroAlmacenDTO()
                        {
                            IdRegistro = Convert.ToInt32(lector[0].ToString()),
                            NombreSucursal = lector[1].ToString(),
                            IdProducto = Convert.ToInt32(lector[2].ToString()),
                            NombreProducto = lector[3].ToString(),
                            Cantidad = Convert.ToInt32(lector[4].ToString())
                        };
                        lista.Add(entidad);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConexionDbInstance.Desconectar();
            }
            return lista;
        }

        /// <summary>
        /// ConsultarPorIdRegistroAlmacen
        /// </summary>
        /// <param name="idRegistro"></param>
        /// <returns></returns>
        public async Task<InformacionConsultaRegistroAlmacenDTO> ConsultarPorIdRegistroAlmacen(int idRegistro)
        {
            InformacionConsultaRegistroAlmacenDTO registroAlmacen = new InformacionConsultaRegistroAlmacenDTO();
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("ConsultarPorIdRegistroAlmacen", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdRegistro", idRegistro));
                SqlDataReader lector = await comando.ExecuteReaderAsync();
                comando.Dispose();

                if (lector.HasRows)
                {
                    lector.Read();
                    registroAlmacen.IdRegistro = Convert.ToInt32(lector[0].ToString());
                    registroAlmacen.NombreSucursal = lector[1].ToString();
                    registroAlmacen.IdProducto = Convert.ToInt32(lector[2].ToString());
                    registroAlmacen.NombreProducto = lector[3].ToString();
                    registroAlmacen.Cantidad = Convert.ToInt32(lector[4].ToString());  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConexionDbInstance.Desconectar();
            }
            return registroAlmacen;
        }

        /// <summary>
        /// ModificarRegistroAlmacen
        /// </summary>
        /// <param name="datosRegistroAlmacen"></param>
        public async Task ModificarRegistroAlmacen(RegistroAlmacen datosRegistroAlmacen)
        {
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("ModificarRegistroAlmacen", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdRegistro", datosRegistroAlmacen.IdRegistro));
                comando.Parameters.Add(new SqlParameter("@IdSucursal", datosRegistroAlmacen.IdSucursal));
                comando.Parameters.Add(new SqlParameter("@IdProducto", datosRegistroAlmacen.IdProducto));
                comando.Parameters.Add(new SqlParameter("@Cantidad", datosRegistroAlmacen.Cantidad));
                await comando.ExecuteNonQueryAsync();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConexionDbInstance.Desconectar();
            }
        }
    }
}
