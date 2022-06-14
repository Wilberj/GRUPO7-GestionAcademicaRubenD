
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Aula
    {
        public string TableName = "Aula";
        public int idAula { get; set; }
public string Nombrel_Aula { get; set; }
        public string Uvicacion { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }


        public object save(Aula inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idAula == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idAula");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object Delete(Aula inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idAula < 0)
                {
                    throw new Exception("Expecifique el idAula");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idAula", inst.idAula);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Aula inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.idAula, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}

