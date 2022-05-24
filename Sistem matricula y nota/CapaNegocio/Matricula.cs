using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Matricula
    {
        public string TableName = "MATRICULA";
        public int IdMatricula { get; set; }

public string Año { get; set; } 

public int IdAlumno { get; set; }
       public int idNIVEL  { get; set; }

    public int idGradoSeccion { get; set; }
      public int   idResponsableAlumno { get; set; }
      public string  Tipo_matricula { get; set; }
public string InstitucionProcedencia { get; set; }
       public Boolean EsRepitente { get; set; }
public Boolean Activo { get; set; }
public string FechaRegistro { get; set; }



        public object save(Matricula inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdMatricula == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idMatricula");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }

   

}
