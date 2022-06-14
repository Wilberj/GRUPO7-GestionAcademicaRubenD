using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Materia
    {
        public string TableName = "Materia";
        public int IdMateria { get; set; }
public string Descripcion { get; set; }
        public int idpensum { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }

        public object save(Materia inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdMateria == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdMateria");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object Delete(Materia inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdMateria < 0)
                {
                    throw new Exception("Expecifique el IdMateria");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "IdMateria", inst.IdMateria);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Materia inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.IdMateria, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
