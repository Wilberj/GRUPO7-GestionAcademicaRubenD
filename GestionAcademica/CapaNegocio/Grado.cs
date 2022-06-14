using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Grado
    {


        public string TableName = "Grado";
        public int IdGrado { get; set; }
public string Nombre_Grado { get; set; }
        public int idNivel1 { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }


        public object save(Grado inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdGrado == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdGrado");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object Delete(Grado inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdGrado < 0)
                {
                    throw new Exception("Expecifique el IdGrado");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "IdGrado", inst.IdGrado);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Grado inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.IdGrado, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
