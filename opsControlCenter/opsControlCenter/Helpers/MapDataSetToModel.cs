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
        ConfigMapModel configMapModel = new ConfigMapModel();

        #region Alarmas

        public List<Alarmas> MapAlarmas()
        {
            using (DataSetObject dataSetObject = new DataSetObject())
            {
                string strModel = "Alarmas";
                string strSQL = "select ala_id, ala_dala_id, dala_descshort, ala_uni_id, uni_descshort, ala_inidate " +
                    "from " + strMunicipio + ".alarms " +
                    "inner join " + strMunicipio + ".alarms_def on alarms.ala_dala_id = alarms_def.dala_id " +
                    "inner join " + strMunicipio + ".units on alarms.ala_uni_id = units.uni_id";

                List<Alarmas> data = new List<Alarmas>();              
                DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
                if (ds.Tables[strModel].Rows.Count > 0)
                {
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

        }

        #endregion

        #region Recaudacion

        public List<Recaudacion> MapRecaudacion()
        {
            using (DataSetObject dataSetObject = new DataSetObject())
            {
                string strModel = "Recaudacion";
                string strSQL = "select COL_ID, COL_UNI_ID, UNI_DESCSHORT, COL_NUM, COL_DATE, COL_INIDATE, COL_ENDDATE, COL_BACK_COL_TOTAL, COL_COIN_SYMBOL " +
                    "from " + strMunicipio + ".collectings " +
                    "inner join " + strMunicipio + ".units on collectings.col_uni_id = units.uni_id";

                List<Recaudacion> data = new List<Recaudacion>();
                DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
                if (ds.Tables[strModel].Rows.Count > 0)
                {
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
        }

        #endregion

        #region Comun

        public List<ALARMS_DEF> MapAlarmsDef()
        {
            using (DataSetObject dataSetObject = new DataSetObject())
            {
                string strModel = "ALARMS_DEF";
                string strSQL = "select * from " + strMunicipio + ".ALARMS_DEF";

                List<ALARMS_DEF> data = new List<ALARMS_DEF>();
                DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
                if (ds.Tables[strModel].Rows.Count > 0)
                {
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
        }

        public ALARMS_DEF MapAlarmsDef(int id)
        {
            using (DataSetObject dataSetObject = new DataSetObject())
            {
                string strModel = "ALARMS_DEF";
                string strSQL = "SELECT * FROM " + strMunicipio + ".ALARMS_DEF WHERE DALA_ID=" + id;

                ALARMS_DEF data = new ALARMS_DEF();
                DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
                if (ds.Tables[strModel].Rows.Count > 0)
                {
                    var config = configMapModel.configAlarmsDef();

                    IMapper iMapper = config.CreateMapper();

                    data = iMapper.Map<DataRow, ALARMS_DEF>(ds.Tables[strModel].Rows[0]);
                }
                return data;
            }
        }

        public List<UNITS> MapUnits()
        {
            using (DataSetObject dataSetObject = new DataSetObject())
            {
                string strModel = "UNITS";
                string strSQL = "select * from " + strMunicipio + ".UNITS";

                List<UNITS> data = new List<UNITS>();
                DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
                if (ds.Tables[strModel].Rows.Count > 0)
                {
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

        #endregion

        #region Usuarios roles

        public Usuario MapUsuarioByLoginName(string USR_LOGIN)
        {
            using (DataSetObject dataSetObject = new DataSetObject())
            {
                string strModel = "Usuario";
                string strSQL = "SELECT * FROM " + strMunicipio + ".USERS INNER JOIN " + strMunicipio + ".ROLES ON USERS.USR_ROL_ID = ROLES.ROL_ID WHERE USR_LOGIN='" + USR_LOGIN + "'";

                Usuario data = new Usuario();
                DataSet ds = dataSetObject.GetDataSet(strSQL, strModel);
                if (ds.Tables[strModel].Rows.Count > 0)
                {
                    var config = configMapModel.configUsuario();

                    IMapper iMapper = config.CreateMapper();

                    data = iMapper.Map<DataRow, Usuario>(ds.Tables[strModel].Rows[0]);
                }
                return data;
            }
        }

        public string[] GetRolesUsuario (string USR_LOGIN)
        {
            Usuario user = MapUsuarioByLoginName(USR_LOGIN);
            string[] roles = new string[] { };

            switch (user.USR_ROL_ID)
            {
                case 0:
                    roles = new string[] { "admin" };
                    break;
                case 1:
                    roles = new string[] { "admin" };
                    break;
                case 2:
                    roles = new string[] { "mant" };
                    break;
                case 3:
                    roles = new string[] { "vigi" };
                    break;
                case 6:
                    roles = new string[] { "user" };
                    break;
                default:
                    roles = new string[] { "user" };
                    break;

            }

            //roles = new string[] { user.ROL_DESCSHORT };
            return roles;
        }

        #endregion

    }
}