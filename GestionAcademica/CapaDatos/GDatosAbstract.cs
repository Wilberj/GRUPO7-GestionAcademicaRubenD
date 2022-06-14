using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace CAPA_DATOS
{
    public abstract class GDatosAbstract
    {
        protected IDbConnection SQLMcon;

        protected abstract IDbConnection CrearConexion(string cadena);

        protected abstract IDbCommand CommandSql(string comandoSql, IDbConnection connection);

        protected abstract IDataAdapter CrearDataAdapterSql(string comandoSql, IDbConnection connection);

        public object ExecuteSqlQuery(string strQuery)
        {
            try
            {
                SQLMcon.Open();
                var com = CommandSql(strQuery, SQLMcon);
                var scalar = com.ExecuteScalar();
                SQLMcon.Close();

                if (scalar == (object)DBNull.Value)
                {
                    return true;
                }
                else
                {
                    return Convert.ToInt32(scalar);
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
        public object ExecuteStoreProc(string strQuery)
        {
            try
            {
                DataSet Ds = new DataSet();

                SQLMcon.Open();
                var com = CommandSql(strQuery, SQLMcon);

                SqlDataAdapter Da = new SqlDataAdapter((SqlCommand)com);

                Da.Fill(Ds);

                SQLMcon.Close();

                if (Ds != null)
                {
                    return int.Parse(Ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public Object InserObject(string TableName, Object Inst)
        {
            try
            {
                var Values = "";
                Type _type = Inst.GetType();
                PropertyInfo[] lst = _type.GetProperties();

                foreach (PropertyInfo oProperty in lst)
                {
                    string AtributeName = oProperty.Name;
                    var AtributeValue = oProperty.GetValue(Inst);

                    if (AtributeValue.GetType() == typeof(string) )
                    {
                        Values = Values + "'" + AtributeValue.ToString() + "',";
                    }
                    else if (AtributeValue.GetType() == typeof(decimal) || AtributeValue.GetType() == typeof(double))
                    {
                        Values = Values + AtributeValue + ",";
                    }

                    else if (AtributeValue.GetType() == typeof(bool))
                    {
                        Values = Values + ((bool)AtributeValue == true ? 1 : 0) + ",";
                    }

                    else if (AtributeValue.GetType() == typeof(DateTime))
                    {
                        Values = Values + "'" + ((DateTime)AtributeValue).ToString("yyyy/MM/dd") + "',";
                    }
                    else
                    {
                        if ((Int32)AtributeValue != -1)
                        {
                            Values = Values + AtributeValue.ToString() + ",";
                        }
                    }
                }
                Values = Values.TrimEnd(',');
                string StrQuery = "INSERT INTO " + TableName + " VALUES (" + Values + ") SELECT SCOPE_IDENTITY()";

                return ExecuteSqlQuery(StrQuery);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Object CallStoreProcedure(string SPName, Object Inst)
        {
            try
            {
                var Values = "";
                var NamesFields = string.Empty;
                Type _type = Inst.GetType();
                PropertyInfo[] lst = _type.GetProperties();

                foreach (PropertyInfo oProperty in lst)
                {
                    string AtributeName = oProperty.Name;
                    var AtributeValue = oProperty.GetValue(Inst);

                    if (AtributeValue.GetType() == typeof(string))
                    {
                        Values = Values + "@"+AtributeName +" = " + "'" + AtributeValue.ToString() + "',";
                    }
                    else if (AtributeValue.GetType() == typeof(decimal) || AtributeValue.GetType() == typeof(double))
                    {
                        Values = Values + "@" + AtributeName + " = " + AtributeValue + ",";
                    }

                    else if (AtributeValue.GetType() == typeof(bool))
                    {
                        Values = Values + "@" + AtributeName + " = " + ((bool)AtributeValue == true ? 1 : 0) + ",";
                    }

                    else if (AtributeValue.GetType() == typeof(DateTime))
                    {
                        Values = Values + "@" + AtributeName + " = " + "'" + ((DateTime)AtributeValue).ToString("yyyy/MM/dd") + "',";
                    }
                    else
                    {
                        if ((Int32)AtributeValue != -1)
                        {
                            Values = Values + "@" + AtributeName + " = " + AtributeValue.ToString() + ",";
                        }
                        else
                        {
                            Values = Values + "@" + AtributeName + " = " + AtributeValue.ToString() + ",";
                        }
                    }

                }
                
                Values = Values.TrimEnd(',');
                string StrQuery = "Exec " + SPName + " " + Values;

                return ExecuteStoreProc(StrQuery);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Object UpdateObject(string TableName, Object Inst, string IdObject)
        {
            try
            {
                var Values = "";
                Type _type = Inst.GetType();
                PropertyInfo[] lst = _type.GetProperties();
                PropertyInfo prop = lst[0];
                foreach (PropertyInfo oProperty in lst)
                {
                    string AtributeName = oProperty.Name;
                    var AtributeValue = oProperty.GetValue(Inst);

                    if (AtributeName != IdObject)
                    {
                        if (AtributeValue.GetType() == typeof(string) || AtributeValue.GetType() == typeof(decimal))
                        {
                            Values = Values + AtributeName + "='" + AtributeValue.ToString() + "',";
                        }
                        else if (AtributeValue.GetType() == typeof(DateTime))
                        {
                            Values = Values + AtributeName + "='" + ((DateTime)AtributeValue).ToString("yyyy/MM/dd") + "',";
                        }
                        else
                        {
                            Values = Values + AtributeName + "=" + AtributeValue.ToString() + ",";
                        }
                    }
                    else
                    {
                        prop = oProperty;
                    }


                }
                Values = Values.TrimEnd(',');
                string StrQuery = "UPDATE " + TableName + " SET " + Values + " WHERE " + IdObject + "=" + prop.GetValue(Inst).ToString();

                return ExecuteSqlQuery(StrQuery);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Object DeleteObject(string TableName, string IdObject, object value)
        {
            try
            {

                string StrQuery = "UPDATE " + TableName + " SET Estado = 0 WHERE " + IdObject + " = " + value;

                return ExecuteSqlQuery(StrQuery);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable TraerDatosSQL(string queryString)
        {
            DataSet ObjDs = new DataSet();
            CrearDataAdapterSql(queryString, SQLMcon).Fill(ObjDs);
            return ObjDs.Tables[0].Copy();
        }

        public Object TakeList(string TableName, Object Inst, string? condition)
        {
            try
            {
                string CondicionString = "";
                if (condition != null)
                {
                    CondicionString = " Where " + condition;
                }
                else
                {
                    CondicionString = " Where Estado= 1";
                }

                string queryString = "Select * from " + TableName + CondicionString;

                DataTable Table = TraerDatosSQL(queryString);

                List<Object> listDb = ConvertDatatable(Table, Inst);

                return listDb;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<Object> ConvertDatatable(DataTable dt, Object Inst)
        {
            List<Object> data = new List<Object>();
            foreach (DataRow row in dt.Rows)
            {
                var item = GetItem(row, Inst);
                data.Add(item);
            }
            return data;
        }

        private static Object GetItem(DataRow dr, Object Inst)
        {
            Type temp = Inst.GetType();
            var obj = Activator.CreateInstance(Inst.GetType());
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        pro.SetValue(obj, dr[column.ColumnName]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return obj;
        }

    }
}
