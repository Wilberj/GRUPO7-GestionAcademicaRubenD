using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Grado_seccion
    {
        public string TableName = "Grado_seccion ";
        public int idGradoSeccion { get; set; }
public string  DescripcionGrado { get; set; }
        public string DescripcionSeccion { get; set; }

        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }


        public object save(Grado_seccion inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idGradoSeccion == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idGradoSeccion");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
