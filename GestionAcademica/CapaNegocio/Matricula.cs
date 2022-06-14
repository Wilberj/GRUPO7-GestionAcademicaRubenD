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
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

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



        public object Delete(Matricula inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdMatricula < 0)
                {
                    throw new Exception("Expecifique el idMatricula");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idMatricula", inst.IdMatricula);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object getMatricula ()
        {
            try {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, InstitucionProcedencia, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }


        public List<Matricula> GetBuscarEstudiante()
        {

            List<Matricula> Lista = new List<Matricula>();


            return Lista;
        }



        public bool MetodPrematricula()
        {
            return true;
        }


        public List<Grado> GetAsignarGrado()
        {

            List<Grado> Lista = new List<Grado>();


            return Lista;
        }

        public List<Matricula> GetRegistroMatricula()
        {

            List<Matricula> Lista = new List<Matricula>();


            return Lista;
        }







    }

   

}
