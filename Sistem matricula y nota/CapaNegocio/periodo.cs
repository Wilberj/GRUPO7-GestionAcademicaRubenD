using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class periodo
    {
        public string TableName = "PERIODO";
        public int IdPeriodo { get; set; }
public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }



        public object save(periodo inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdPeriodo == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdPeriodo");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
