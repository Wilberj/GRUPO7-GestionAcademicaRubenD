using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Docente
    {
        public string TableName = "Estudiante";

        public int idDocente { get; set; }
 public string Nombre_docente { get; set; }
        public string Apellido_M_docente { get; set; }
        public string apellido_p_docente { get; set; }
        public string sexo_docente { get; set; }
        public string direccion_docente { get; set; }
        public string Telefono_docente { get; set; }
        public string Fecha_nacimineto_docente { get; set; }
        public string Email_docente { get; set; }
        public int  idHorario_Docente { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }


        public object save(Estudiante inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idEstudiante == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idEstudiante");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }


        public object Delete(Docente inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idDocente < 0)
                {
                    throw new Exception("Expecifique el idDocente");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idDocente", inst.idDocente);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Docente inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.idDocente, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
