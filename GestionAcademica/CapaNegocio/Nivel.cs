using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CapaNegocio
{
    internal class Nivel
    {
        public string TableName = "NIVEL";
        public int IdNivel { get; set; }
 public int IdPeriodo { get; set; }
        public string DescripcionNivel { get; set; }
        public string  DescripcionTurno { get; set; }
        public string  HoraInicio { get; set; }
        public string  HoraFin { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }

        public object save(Nivel inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdNivel == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "IdNivel");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object Delete(Nivel inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.IdNivel < 0)
                {
                    throw new Exception("Expecifique el IdNivel");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "IdNivel", inst.IdNivel);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Nivel inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.IdNivel, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
