using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infraestructura.Providers
{
    public class ConexionDb
    {
        #region singleton

        private static ConexionDb instance;

        private ConexionDb() { }

        /// <summary>
        /// Instancia unica y estática de la clase
        /// </summary>
        public static ConexionDb GetInstance()
        {
            if (instance == null)
            {
                instance = new ConexionDb();
            }
            return instance;
        }

        #endregion singleton


        public SqlConnection cnn;

        public void Conectar()
        {
            try
            {
                cnn = new SqlConnection("Data Source=DESKTOP-56S2VVJ;Initial Catalog=TiendaReal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Desconectar()
        {
            try
            {
                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
