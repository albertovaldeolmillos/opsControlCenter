using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace opsControlCenter.Helpers
{
    public class DataSetObject
    {
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
    }
}