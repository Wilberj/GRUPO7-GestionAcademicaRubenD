using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;

namespace CapaNegocio
{
    internal class Grupo
    {
        public string TableName = "Grupo";
        public int     idGrupo { get; set; }
        public int  TotalVacantes { get; set; }
        public int VacantesDisponibles { get; set; }
        public int VacantesOcupados { get; set; }
        public int idAula1 { get; set; }
        public Boolean Activo { get; set; }
        public string FechaRegistro { get; set; }





        public object save(Grupo inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idGrupo == -1)
                {
                    return SqlADOConexion.SQLM.InserObject(TableName, inst);

                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, inst, "idGrupo");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object Delete(Grupo inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");


                if (inst.idGrupo < 0)
                {
                    throw new Exception("Expecifique el idGrupo");

                }
                else
                {
                    return SqlADOConexion.SQLM.DeleteObject(TableName, "idGrupo", inst.idGrupo);
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object TakeList(Grupo inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, inst.idGrupo, null);


            }
            catch (Exception e)
            {
                throw;
            }
        }



    

}
}
