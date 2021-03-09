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
        public List<Alarmas> MapAlarms()
        {
            string strModel = "Alarmas";
            string strSQL = "select ala_id as Id, dala_id as idTipo, dala_descshort as Tipo, ala_uni_id as Unidad, ala_inidate as Inicio from " + strMunicipio + ".alarms inner join " + strMunicipio + ".alarms_def on alarms.ala_dala_id = alarms_def.dala_id";

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
    }
}