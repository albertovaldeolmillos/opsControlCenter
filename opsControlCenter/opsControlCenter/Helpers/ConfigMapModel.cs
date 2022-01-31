using AutoMapper;
using AutoMapper.Configuration;
using opsControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace opsControlCenter.Helpers
{
    public class ConfigMapModel
    {
        MapperConfiguration mapperConfiguration { get; set; }

        #region general
        MapperConfiguration configMapper<T>()
        {
            MapperConfigurationExpression mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AllowNullCollections = true;
            mapperConfigurationExpression.AllowNullDestinationValues = true;
            IMappingExpression mappingExpression = mapperConfigurationExpression.CreateMap(typeof(DataRow), typeof(T));
            foreach (var elem in typeof(T).GetProperties())
            {
                if (Type.GetTypeCode(elem.PropertyType) == TypeCode.DateTime || elem.PropertyType == typeof(DateTime) || elem.PropertyType == typeof(DateTime?))
                    mappingExpression.ForMember(elem.Name, o => o.MapFrom(s => ((DataRow)s).IsNull(elem.Name) ? DateTime.Now : (((DataRow)s)[elem.Name].ToString() == "") ? DateTime.Now : ((DataRow)s)[elem.Name]));
                else if (elem.PropertyType == typeof(decimal) || elem.PropertyType == typeof(decimal?))
                    mappingExpression.ForMember(elem.Name, o => o.MapFrom(s => ((DataRow)s).IsNull(elem.Name) ? 0 : (((DataRow)s)[elem.Name].ToString() == "") ? 0 : ((DataRow)s)[elem.Name]));
                else
                    mappingExpression.ForMember(elem.Name, o => o.MapFrom(s => ((DataRow)s)[elem.Name]));
            }
            MapperConfiguration config = new MapperConfiguration(mapperConfigurationExpression);
            return config;
        }
        #endregion

        #region Alarmas
        public MapperConfiguration configAlarmas()
        {
            return configMapper<Alarmas>();

            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<DataRow, Alarmas>()
            //        .ForMember(d => d.ALA_ID, o => o.MapFrom(s => s["ALA_ID"]))
            //        .ForMember(d => d.ALA_DALA_ID, o => o.MapFrom(s => s["ALA_DALA_ID"]))
            //        .ForMember(d => d.ALA_UNI_ID, o => o.MapFrom(s => s["ALA_UNI_ID"]))
            //        .ForMember(d => d.DALA_DESCSHORT, o => o.MapFrom(s => s["DALA_DESCSHORT"]))
            //        .ForMember(d => d.UNI_DESCSHORT, o => o.MapFrom(s => s["UNI_DESCSHORT"]))
            //        .ForMember(d => d.ALA_INIDATE, o => o.MapFrom(s => s.IsNull("ALA_INIDATE") ? DateTime.Now : s["ALA_INIDATE"]));
            //    cfg.AllowNullCollections = true;
            //    cfg.AllowNullDestinationValues = true;
            //}

            // );
            //return config;

            //AutoMapper.Configuration.MapperConfigurationExpression mapperConfigurationExpression = new AutoMapper.Configuration.MapperConfigurationExpression();
            //mapperConfigurationExpression.AllowNullCollections = true;
            //mapperConfigurationExpression.AllowNullDestinationValues = true;
            //IMappingExpression mappingExpression = mapperConfigurationExpression.CreateMap(typeof(DataRow), typeof(Alarmas));
            //mappingExpression.ForMember("ALA_ID", o => o.MapFrom(s => ((DataRow)s)["ALA_ID"]));
            //mappingExpression.ForMember("ALA_DALA_ID", o => o.MapFrom(s => ((DataRow)s)["ALA_DALA_ID"]));
            //mappingExpression.ForMember("ALA_UNI_ID", o => o.MapFrom(s => ((DataRow)s)["ALA_UNI_ID"]));
            //mappingExpression.ForMember("DALA_DESCSHORT", o => o.MapFrom(s => ((DataRow)s)["DALA_DESCSHORT"]));
            //mappingExpression.ForMember("UNI_DESCSHORT", o => o.MapFrom(s => ((DataRow)s)["UNI_DESCSHORT"]));
            //mappingExpression.ForMember("ALA_INIDATE", o => o.MapFrom(s => ((DataRow)s).IsNull("ALA_INIDATE") ? DateTime.Now : ((DataRow)s)["ALA_INIDATE"]));
            //var config = new MapperConfiguration(mapperConfigurationExpression);
            //return config;

            //MapperConfigurationExpression mapperConfigurationExpression = new MapperConfigurationExpression();
            //mapperConfigurationExpression.AllowNullCollections = true;
            //mapperConfigurationExpression.AllowNullDestinationValues = true;
            //IMappingExpression mappingExpression = mapperConfigurationExpression.CreateMap(typeof(DataRow), typeof(Alarmas));
            //foreach (var elem in typeof(Alarmas).GetProperties()){
            //    if (Type.GetTypeCode(elem.PropertyType) == TypeCode.DateTime || elem.PropertyType == typeof(DateTime) || elem.PropertyType == typeof(DateTime?))
            //        mappingExpression.ForMember(elem.Name, o => o.MapFrom(s => ((DataRow)s).IsNull(elem.Name) ? DateTime.Now : ((DataRow)s)[elem.Name]));
            //    else
            //        mappingExpression.ForMember(elem.Name, o => o.MapFrom(s => ((DataRow)s)[elem.Name]));
            //}
            //var config = new MapperConfiguration(mapperConfigurationExpression);
            //return config;
        }

        #endregion

        #region Mapa
        public MapperConfiguration configAlarmsByUnitId()
        {
            return configMapper<AlarmasPorUnidad>();
        }

        public MapperConfiguration configOperationsByUnitId()
        {
            return configMapper<OperacionesPorUnidad>();
        }
        public MapperConfiguration configUnidadesMapa()
        {
            return configMapper<UnidadesMapa>();
        }

        public MapperConfiguration configUnidadesInstalacion()
        {
            return configMapper<UnidadesInstalacion>();
        }
        #endregion

        #region Recaudacion
        public MapperConfiguration configRecaudacion()
        {
            return configMapper<Recaudacion>();
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<DataRow, Recaudacion>()
            //        .ForMember(d => d.COL_ID, o => o.MapFrom(s => s["COL_ID"]))
            //        .ForMember(d => d.COL_UNI_ID, o => o.MapFrom(s => s["COL_UNI_ID"]))
            //        .ForMember(d => d.UNI_DESCSHORT, o => o.MapFrom(s => s["UNI_DESCSHORT"]))
            //        .ForMember(d => d.COL_NUM, o => o.MapFrom(s => s["COL_NUM"]))
            //        .ForMember(d => d.COL_COIN_SYMBOL, o => o.MapFrom(s => s["COL_COIN_SYMBOL"]))
            //        .ForMember(d => d.COL_BACK_COL_TOTAL, o => o.MapFrom(s => s["COL_BACK_COL_TOTAL"]))
            //        .ForMember(d => d.COL_DATE, o => o.MapFrom(s => s.IsNull("COL_DATE") ? DateTime.Now : s["COL_DATE"]))
            //        .ForMember(d => d.COL_INIDATE, o => o.MapFrom(s => s.IsNull("COL_INIDATE") ? DateTime.Now : s["COL_INIDATE"]))
            //        .ForMember(d => d.COL_ENDDATE, o => o.MapFrom(s => s.IsNull("COL_ENDDATE") ? DateTime.Now : s["COL_ENDDATE"]))
            //        ;
            //    cfg.AllowNullCollections = true;
            //    cfg.AllowNullDestinationValues = true;
            //}

            // );
            //return config;
        }
        #endregion

        #region Comun

        public MapperConfiguration configAlarmsDef()
        {
            return configMapper<ALARMS_DEF>();
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<DataRow, ALARMS_DEF>()
            //        .ForMember(d => d.DALA_ID, o => o.MapFrom(s => s["DALA_ID"]))
            //        .ForMember(d => d.DALA_DESCSHORT, o => o.MapFrom(s => s["DALA_DESCSHORT"]))
            //        .ForMember(d => d.DALA_DESCLONG, o => o.MapFrom(s => s["DALA_DESCLONG"]));
            //    cfg.AllowNullCollections = true;
            //    cfg.AllowNullDestinationValues = true;
            //}

            // );
            //return config;
        }

        public MapperConfiguration configUnits()
        {
            return configMapper<UNITS>();
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<DataRow, UNITS>()
            //        .ForMember(d => d.UNI_ID, o => o.MapFrom(s => s["UNI_ID"]))
            //        .ForMember(d => d.UNI_DESCSHORT, o => o.MapFrom(s => s["UNI_DESCSHORT"]))
            //        .ForMember(d => d.UNI_DESCLONG, o => o.MapFrom(s => s["UNI_DESCLONG"]))
            //        .ForMember(d => d.UNI_IP, o => o.MapFrom(s => s["UNI_IP"]))
            //        .ForMember(d => d.UNI_VALID, o => o.MapFrom(s => s["UNI_VALID"]))
            //        .ForMember(d => d.UNI_DELETED, o => o.MapFrom(s => s["UNI_DELETED"]))
            //        .ForMember(d => d.UNI_DATE, o => o.MapFrom(s => s.IsNull("UNI_DATE") ? DateTime.Now : s["UNI_DATE"]));
            //    cfg.AllowNullCollections = true;
            //    cfg.AllowNullDestinationValues = true;
            //}

            // );
            //return config;
        }

        public MapperConfiguration configCollectings()
        {
            return configMapper<COLLECTINGS>();
        }
        #endregion

        #region Usuario rol
        public MapperConfiguration configUsuario()
        {
            return configMapper<Usuario>();
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<DataRow, Usuario>()
            //        .ForMember(d => d.USR_ID, o => o.MapFrom(s => s["USR_ID"]))
            //        .ForMember(d => d.USR_ROL_ID, o => o.MapFrom(s => s["USR_ROL_ID"]))
            //        .ForMember(d => d.USR_LOGIN, o => o.MapFrom(s => s["USR_LOGIN"]))
            //        .ForMember(d => d.USR_PASSWORD, o => o.MapFrom(s => s["USR_PASSWORD"]))
            //        .ForMember(d => d.ROL_DESCSHORT, o => o.MapFrom(s => s["ROL_DESCSHORT"]));
            //    cfg.AllowNullCollections = true;
            //    cfg.AllowNullDestinationValues = true;
            //}

            // );
            //return config;
        }

        #endregion
    }
}