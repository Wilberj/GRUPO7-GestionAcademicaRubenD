using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Calificacion
    {
        public string TableName = "CALIFICACION";
    public int IdCalificacion { get; set; }
   public string Nombre_evaluacion { get; set; }
        public float nota { get; set; }
        public string Estado_calificacion { get; set; }
        public string Semestre { get; set; }
        public int idMateria1 { get; set; }
        public int idAlumno1 { get; set; }
        public int idPeriodo { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }





        public object save(Calificacion inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdCalificacion == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdCalificacion");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object Delete(Calificacion inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdCalificacion < 0)
                {
                    throw new Exception("Expecifique el idMatricula");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idMatricula", inst.IdCalificacion);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Calificacion inst )
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.IdCalificacion, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Estudiante> GetAsignarcalificasion()
        {

            List<Estudiante> Lista = new List<Estudiante>();


            return Lista;
        }


        public List<Estudiante> GetBuscarEstudiantemodificarnota()
        {

            List<Estudiante> Estudiante = new List<Estudiante>();


            return Estudiante;
        }
        public List<Calificacion> GetRegistroCalificasiones()
        {

            List<Calificacion> Lista = new List<Calificacion>();


            return Lista;
        }
        public List<Grupo> Getcalcularpromedio()
        {

            List<Grupo> promedio = new List<Grupo>();


            return promedio;
        }



    }
}
