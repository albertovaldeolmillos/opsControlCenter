using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace opsControlCenter.Helpers
{
    public class DataSetObject: IDisposable
    {
        private bool disposedValue;

        public DataSet dataSet { get; set; }
        public DataSet GetDataSet(string strSQL, string strModel)
        {
            string oradb = ConfigurationManager.AppSettings["OracleDataAccess"];
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(oradb))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = strSQL;
                        OracleDataAdapter oDa = new OracleDataAdapter(cmd);

                        oDa.Fill(ds, strModel);

                        con.Close(); ;
                        //ViewBag.Message = strModel + " lista:";
                    }
                    catch (Exception ex)
                    {
                        //ViewBag.Message = "page." + "error:" + ex.Message;
                    }
                }
            }

            return ds;
        }

        public void UpdateTableParam(string table, string param, string paramValue, string id, string idvalue)
        {
            string strMunicipio = ConfigurationManager.AppSettings["OPSMunicipio"];
            string oradb = ConfigurationManager.AppSettings["OracleDataAccess"];
            using (OracleConnection con = new OracleConnection(oradb))
            {
                //string strSQL = "update @strMunicipio.@table set @param=@paramValue where @id=@idvalue";
                //string strSQL = "update :strMunicipio.:table set :param = :paramValue where :id = :idvalue";
                string strSQL = "update " + strMunicipio + "." + table + " set " + param + "=" + paramValue + " where " + id + "=" + idvalue;

                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        //cmd.Parameters.Add("strMunicipio", SqlDbType.NChar).Value = strMunicipio;
                        //cmd.Parameters.Add("table", SqlDbType.NChar).Value = table;
                        //cmd.Parameters.Add("param", SqlDbType.NChar).Value = param;
                        //cmd.Parameters.Add("paramValue", SqlDbType.NChar).Value = paramValue;
                        //cmd.Parameters.Add("id", SqlDbType.NChar).Value = id;
                        //cmd.Parameters.Add("idvalue", SqlDbType.NChar).Value = idvalue;
                        //cmd.Parameters.Add("strMunicipio", strMunicipio);
                        //cmd.Parameters.Add("table", table);
                        //cmd.Parameters.Add("param", param);
                        //cmd.Parameters.Add("paramValue", paramValue);
                        //cmd.Parameters.Add("id", id);
                        //cmd.Parameters.Add("idvalue", idvalue);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strSQL;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }           
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~DataSetObject()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}