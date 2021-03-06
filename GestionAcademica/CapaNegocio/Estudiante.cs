using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Estudiante
    {
        public string TableName = "Estudiante";
        public int idEstudiante { get; set; }
public string Nombre_Estudiante { get; set; }
        public string Apellido_M_Estudiante { get; set; }
        public string apellido_p_Estudiante { get; set; }
        public string sexo_Estudiante { get; set; }
        public string direccion_Estudiante { get; set; }
        public string Telefono_Estudiante { get; set; }
        public string Fecha_nacimineto_Estudiante { get; set; }
        public string Discapacidad_Estudiante { get; set; }
        public int idDocumento { get; set; }
        public int idHorario_Estudiante { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }





        public object save(Docente inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idDocente == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idDocente");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }


        public object Delete(Estudiante inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idEstudiante < 0)
                {
                    throw new Exception("Expecifique el idEstudiante");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idEstudiante", inst.idEstudiante);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Estudiante inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.idEstudiante, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
