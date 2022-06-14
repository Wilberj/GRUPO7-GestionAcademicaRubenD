using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Pensum
    {
        public string TableName = "Pensum";
        public int idPensum { get; set; }
public string Año_lectivo { get; set; }

        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }


        public object save(Pensum inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idPensum == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idPensum");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }


        public object Delete(Pensum  inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idPensum < 0)
                {
                    throw new Exception("Expecifique el IdPeriodo");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idPensum", inst.idPensum);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Pensum inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.idPensum, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
