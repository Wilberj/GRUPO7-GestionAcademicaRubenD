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
public string Cualitativa_primer_corte { get; set; }
        public string Cuantitativa_primar_corte { get; set; }
        public string Cualitativa_segundo_corte { get; set; }
        public string Cuantitativa_segundo_corte { get; set; }
        public string Primer_semestre { get; set; }
        public string Cualitativa_Tercer_corte { get; set; }
        public string Cuantitativa_Tercer_corte { get; set; }
        public string Cualitativa_cuarto_corte { get; set; }
        public string Cuantitativa_Cuarto_corte { get; set; }
        public string Segundo_semestre { get; set; }
        public string Nota_final { get; set; }
        public int IdEstudiante1 { get; set; }
        public int idMateria1 { get; set; }
        public int idDocente { get; set; }
        public Boolean Activo { get; set; }
        public string  FechaRegistro { get; set; }





        public object save(Calificacion inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdCalificacion == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

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


    }
}
