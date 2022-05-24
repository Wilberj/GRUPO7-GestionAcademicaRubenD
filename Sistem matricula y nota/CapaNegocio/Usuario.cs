using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Usuario
    {
        public string TableName = "USUARIO";
        public int IdUsuario { get; set; }
public int IdRol { get; set; }
        public string  LoginUsuario { get; set; }
        public string LoginClave { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }

        public object save(Usuario inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");



                if (inst.IdUsuario == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdUsuario");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
