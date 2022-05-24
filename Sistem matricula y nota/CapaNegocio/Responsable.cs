using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;

namespace CapaNegocio
{
    internal class Responsable
    {
        public string TableName = "Responsable_Alumno";
        public int idResponsable_Alumno { get; set; }
public string TipoRelacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }


        public object save(Responsable inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idResponsable_Alumno == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idResponsable_Alumno");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
