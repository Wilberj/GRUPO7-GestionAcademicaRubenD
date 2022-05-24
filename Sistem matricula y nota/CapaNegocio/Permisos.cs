using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Permisos
    {
        public string TableName = "PERMISOS";
        public int IdPermisos { get; set; }
public int IdRol { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }

        public object save(Permisos inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");



                if (inst.IdPermisos == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdPermisos");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
