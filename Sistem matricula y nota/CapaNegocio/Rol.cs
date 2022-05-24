using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Rol
    {
        public string TableName = "ROL";
        public int IdRol { get; set; }
public string Descripcion { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }

        public object save(Rol inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");



                if (inst.IdRol == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdRol");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
