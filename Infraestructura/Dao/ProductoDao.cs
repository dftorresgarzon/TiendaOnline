using Dominio.DTOs;
using Dominio.Entities;
using Infraestructura.Providers;
using System.Data.SqlClient;

namespace Infraestructura.Dao
{
    public class ProductoDao
    {
        /// <summary>
        /// Obtiene la instancia Singleton de ConexionDb
        /// </summary>
        ConexionDb ConexionDbInstance = ConexionDb.GetInstance();

        /// <summary>
        /// ConsultarTodosProductos
        /// </summary>
        /// <returns></returns>
        public async Task<List<InformacionConsultaProductoDTO>> ConsultarTodosProductos()
        {
            List<InformacionConsultaProductoDTO> lista = new List<InformacionConsultaProductoDTO>();
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("ConsultarTodosProductos", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = await comando.ExecuteReaderAsync();
                comando.Dispose();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        InformacionConsultaProductoDTO entidad = new InformacionConsultaProductoDTO()
                        {
                            IdProducto = Convert.ToInt32(lector[0].ToString()),
                            NombreFabricante = lector[1].ToString(),
                            Forma = lector[2].ToString(),
                            NombreProducto = lector[3].ToString(),
                            TamanioCm3 = Convert.ToInt32(lector[4].ToString()),
                            Precio = Convert.ToDecimal(lector[5].ToString(), System.Globalization.CultureInfo.InvariantCulture),
                            IdSubdepartamento = Convert.ToInt32(lector[6].ToString()),
                            UrlImagen = lector[7].ToString()
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
        /// ConsultarPorIdProducto
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public async Task<InformacionConsultaProductoDTO> ConsultarPorIdProducto(int idProducto)
        {
            InformacionConsultaProductoDTO producto = new InformacionConsultaProductoDTO();
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("ConsultarPorIdProducto", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdProducto", idProducto));
                SqlDataReader lector = await comando.ExecuteReaderAsync();
                comando.Dispose();

                if (lector.HasRows)
                {
                    lector.Read();
                    producto.IdProducto = Convert.ToInt32(lector[0].ToString());
                    producto.NombreFabricante = lector[1].ToString();
                    producto.Forma = lector[2].ToString();
                    producto.NombreProducto = lector[3].ToString();
                    producto.TamanioCm3 = Convert.ToInt32(lector[4].ToString());
                    producto.Precio = Convert.ToDecimal(lector[5].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    producto.IdSubdepartamento = Convert.ToInt32(lector[6].ToString());
                    producto.UrlImagen = lector[7].ToString();  
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
            return producto;
        }

        /// <summary>
        /// GuardarProducto
        /// </summary>
        /// <param name="datosProducto"></param>
        public async Task GuardarProducto(Producto datosProducto)
        {
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("GuardarProducto", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdTipoEmpaque", datosProducto.IdTipoEmpaque));
                comando.Parameters.Add(new SqlParameter("@IdFabricante", datosProducto.IdFabricante));
                comando.Parameters.Add(new SqlParameter("@IdSubdepartamento", datosProducto.IdSubdepartamento));
                comando.Parameters.Add(new SqlParameter("@NombreProducto", datosProducto.NombreProducto));
                comando.Parameters.Add(new SqlParameter("@TamanioCm3", datosProducto.TamanioCm3));
                comando.Parameters.Add(new SqlParameter("@Precio", datosProducto.Precio));
                comando.Parameters.Add(new SqlParameter("@Caracteristicas", datosProducto.Caracteristicas));
                comando.Parameters.Add(new SqlParameter("@UrlImagen", datosProducto.UrlImagen));
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

        /// <summary>
        /// ModificarProducto
        /// </summary>
        /// <param name="datosProducto"></param>
        public async Task ModificarProducto(Producto datosProducto)
        {
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("ModificarProducto", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdTipoEmpaque", datosProducto.IdTipoEmpaque));
                comando.Parameters.Add(new SqlParameter("@IdFabricante", datosProducto.IdFabricante));
                comando.Parameters.Add(new SqlParameter("@IdSubdepartamento", datosProducto.IdSubdepartamento));
                comando.Parameters.Add(new SqlParameter("@NombreProducto", datosProducto.NombreProducto));
                comando.Parameters.Add(new SqlParameter("@TamanioCm3", datosProducto.TamanioCm3));
                comando.Parameters.Add(new SqlParameter("@Precio", datosProducto.Precio));
                comando.Parameters.Add(new SqlParameter("@Caracteristicas", datosProducto.Caracteristicas));
                comando.Parameters.Add(new SqlParameter("@UrlImagen", datosProducto.UrlImagen));
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

        /// <summary>
        /// EliminarProducto
        /// </summary>
        /// <param name="idProducto"></param>
        public async Task EliminarProducto(int idProducto)
        {
            try
            {
                ConexionDbInstance.Conectar();
                SqlCommand comando = new SqlCommand("EliminarProducto", ConexionDbInstance.cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdProducto", idProducto));
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
