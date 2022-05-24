using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class intermediaMateGrado
    {
        public string TableName = "intermediaMateGrado";
        public int idintermediaMateGrado { get; set; }
public int  idgradoseccion { get; set; }
        public int  idMateria { get; set; }

        public Boolean Activo { get; set; }
        public string  FechaRegistro { get; set; }


        public object save(intermediaDocenteGrado inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idintermediaDocente == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idintermediaDocente");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
