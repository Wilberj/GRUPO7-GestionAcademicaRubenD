using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Nivel
    {
        public string TableName = "NIVEL";
        public int IdNivel { get; set; }
 public int IdPeriodo { get; set; }
        public string DescripcionNivel { get; set; }
        public string  DescripcionTurno { get; set; }
        public string  HoraInicio { get; set; }
        public string  HoraFin { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }

        public object save(Nivel inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdNivel == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdNivel");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
