using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class GuiaGrado
    {
        public string TableName = "GuiaGrado";
        public int idGuiaGrado { get; set; }
 public int idDocente1 { get; set; }
        public int idNIVEL1 { get; set; }
        public int idSeccionGrado { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }



        public object save(GuiaGrado inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idGuiaGrado == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idGuiaGrado");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
