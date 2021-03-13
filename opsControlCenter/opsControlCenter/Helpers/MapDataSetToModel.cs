using AutoMapper;
using opsControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace opsControlCenter.Helpers
{
    public class MapDataSetToModel
    {
        string strMunicipio = ConfigurationManager.AppSettings["OPSMunicipio"];

        #region Alarmas

        public List<Alarmas> MapAlarms()
        {
            string strModel = "Alarmas";
            string strSQL = "select ala_id, ala_dala_id, dala_descshort as Tipo, ala_uni_id, uni_descshort as Unidad, ala_inidate " +
                "from " + strMunicipio + ".alarms " +
                "inner join " + strMunicipio + ".alarms_def on alarms.ala_dala_id = alarms_def.dala_id " +
                "inner join " + strMunicipio + ".units on alarms.ala_uni_id = units.uni_id";

            List<Alarmas> data = new List<Alarmas>();
            DataSetObject dataSetObject = new DataSetObject();
            DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
            if (ds.Tables[strModel].Rows.Count > 0)
            {
                ConfigMapModel configMapModel = new ConfigMapModel();
                var config = configMapModel.configAlarmas();

                IMapper iMapper = config.CreateMapper();

                int cont = 0;
                foreach (DataRow row in ds.Tables[strModel].Rows)
                {
                    Alarmas elem = iMapper.Map<DataRow, Alarmas>(ds.Tables[strModel].Rows[cont]);
                    data.Add(elem);
                    cont++;
                }
            }
            return data;
        }

        #endregion

        #region Recaudacion

        public List<Recaudacion> MapRecaudacion()
        {
            string strModel = "Recaudacion";
            string strSQL = "select COL_ID, COL_UNI_ID, COL_NUM, COL_DATE, COL_INIDATE, COL_ENDDATE, COL_BACK_COL_TOTAL, COL_COIN_SYMBOL from " + strMunicipio + ".collectings";

            List<Recaudacion> data = new List<Recaudacion>();
            DataSetObject dataSetObject = new DataSetObject();
            DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
            if (ds.Tables[strModel].Rows.Count > 0)
            {
                ConfigMapModel configMapModel = new ConfigMapModel();
                var config = configMapModel.configRecaudacion();

                IMapper iMapper = config.CreateMapper();

                int cont = 0;
                foreach (DataRow row in ds.Tables[strModel].Rows)
                {
                    Recaudacion elem = iMapper.Map<DataRow, Recaudacion>(ds.Tables[strModel].Rows[cont]);
                    data.Add(elem);
                    cont++;
                }
            }
            return data;
        }

        #endregion

        #region Comun

        public List<ALARMS_DEF> MapAlarmsDef()
        {
            string strModel = "ALARMS_DEF";
            string strSQL = "select * from " + strMunicipio + ".ALARMS_DEF";

            List<ALARMS_DEF> data = new List<ALARMS_DEF>();
            DataSetObject dataSetObject = new DataSetObject();
            DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
            if (ds.Tables[strModel].Rows.Count > 0)
            {
                ConfigMapModel configMapModel = new ConfigMapModel();
                var config = configMapModel.configAlarmsDef();

                IMapper iMapper = config.CreateMapper();

                int cont = 0;
                foreach (DataRow row in ds.Tables[strModel].Rows)
                {
                    ALARMS_DEF elem = iMapper.Map<DataRow, ALARMS_DEF>(ds.Tables[strModel].Rows[cont]);
                    data.Add(elem);
                    cont++;
                }
            }
            return data;
        }

        public ALARMS_DEF MapAlarmsDef(int id)
        {
            string strModel = "ALARMS_DEF";
            string strSQL = "SELECT * FROM ALARMS_DEF WHERE DALA_ID=" + id;

            ALARMS_DEF data = new ALARMS_DEF();
            DataSetObject dataSetObject = new DataSetObject();
            DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
            if (ds.Tables[strModel].Rows.Count > 0)
            {
                ConfigMapModel configMapModel = new ConfigMapModel();
                var config = configMapModel.configAlarmsDef();

                IMapper iMapper = config.CreateMapper();

                data = iMapper.Map<DataRow, ALARMS_DEF>(ds.Tables[strModel].Rows[0]);
            }
            return data;
        }

        public List<UNITS> MapUnits()
        {
            string strModel = "UNITS";
            string strSQL = "select * from " + strMunicipio + ".UNITS";

            List<UNITS> data = new List<UNITS>();
            DataSetObject dataSetObject = new DataSetObject();
            DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
            if (ds.Tables[strModel].Rows.Count > 0)
            {
                ConfigMapModel configMapModel = new ConfigMapModel();
                var config = configMapModel.configUnits();

                IMapper iMapper = config.CreateMapper();

                int cont = 0;
                foreach (DataRow row in ds.Tables[strModel].Rows)
                {
                    UNITS elem = iMapper.Map<DataRow, UNITS>(ds.Tables[strModel].Rows[cont]);
                    data.Add(elem);
                    cont++;
                }
            }
            return data;
        }

        #endregion

    }
}