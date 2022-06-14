using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA_DATOS
{
    public class SqlADOConexion
    {
        static string UserSQLConexion = "";
        public static SqlServerGDatos SQLM;

        static public bool IniciarConexion(string user, string password)
        {
            try
            {
                UserSQLConexion = "Data Source=DESKTOP-8EMO9AJ;Initial Catalog=DB_LICORERIA;Integrated Security=True";
                SQLM = new SqlServerGDatos(UserSQLConexion);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
