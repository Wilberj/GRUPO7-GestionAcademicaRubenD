using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class intermediaDocenteGrado
    {
        public string TableName = "intermediaDocente";
        public int idintermediaDocente { get; set; }
        public int idGradoSeccion { get; set; }
        public int idDocente { get; set; }
     public Boolean   Activo { get; set; }
public string FechaRegistro { get; set; }

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
