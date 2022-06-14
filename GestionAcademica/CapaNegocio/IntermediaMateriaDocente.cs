using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class IntermediaMateriaDocente
    {
        public string TableName = "IntermediaMateriaDocente";
        public int idIntermediaMateriaDocente { get; set; }
        public int idMateria3 { get; set; }
        public int idDocente { get; set; }
      

        public object save(IntermediaMateriaDocente inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idIntermediaMateriaDocente == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idIntermediaMateriaDocente");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object Delete(IntermediaMateriaDocente inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idIntermediaMateriaDocente < 0)
                {
                    throw new Exception("Expecifique el idIntermediaMateriaDocente");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "IdGrado", inst.idIntermediaMateriaDocente);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(IntermediaMateriaDocente inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.idIntermediaMateriaDocente, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
