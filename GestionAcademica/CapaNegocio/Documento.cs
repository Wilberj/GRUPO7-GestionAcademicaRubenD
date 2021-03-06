using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Documento
    {
        public string TableName = "Documento"; 
        public int idDocumento { get; set; }
   public string fichero { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }


        public object save(Documento inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idDocumento == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idDocumento");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }



        public object Delete(Documento inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idDocumento < 0)
                {
                    throw new Exception("Expecifique el idDocumento");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idDocumento", inst.idDocumento);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Documento inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.idDocumento, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
