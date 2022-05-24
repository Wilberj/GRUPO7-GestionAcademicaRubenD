using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class intermedia__GradoNivel
    {
        public string TableName = "GradoNivel";
        public int  idGradoNivel { get; set; }
 public int IdNivel { get; set; }
        public int IdGradoSeccion { get; set; }
        public int TotalVacantes { get; set; }
        public int VacantesDisponibles { get; set; }
        public int VacantesOcupados { get; set; }
        public Boolean Activo { get; set; }
      public string  FechaRegistro { get; set; }



        public object save(intermedia__GradoNivel inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idGradoNivel == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idGradoNivel");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
