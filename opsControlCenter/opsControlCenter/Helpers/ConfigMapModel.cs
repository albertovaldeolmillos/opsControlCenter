using AutoMapper;
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

        #region Alarmas
        public MapperConfiguration configAlarmas()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataRow, Alarmas>()
                    .ForMember(d => d.ALA_ID, o => o.MapFrom(s => s["ALA_ID"]))
                    .ForMember(d => d.ALA_DALA_ID, o => o.MapFrom(s => s["ALA_DALA_ID"]))
                    .ForMember(d => d.ALA_UNI_ID, o => o.MapFrom(s => s["ALA_UNI_ID"]))
                    .ForMember(d => d.Tipo, o => o.MapFrom(s => s["Tipo"]))
                    .ForMember(d => d.Unidad, o => o.MapFrom(s => s["Unidad"]))
                    .ForMember(d => d.ALA_INIDATE, o => o.MapFrom(s => s.IsNull("ALA_INIDATE") ? DateTime.Now : s["ALA_INIDATE"]));
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            }

             );
            return config;
        }

        #endregion

        #region Recaudacion
        public MapperConfiguration configRecaudacion()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataRow, Recaudacion>()
                    .ForMember(d => d.COL_ID, o => o.MapFrom(s => s["COL_ID"]))
                    .ForMember(d => d.COL_UNI_ID, o => o.MapFrom(s => s["COL_UNI_ID"]))
                    .ForMember(d => d.COL_NUM, o => o.MapFrom(s => s["COL_NUM"]))
                    .ForMember(d => d.COL_COIN_SYMBOL, o => o.MapFrom(s => s["COL_COIN_SYMBOL"]))
                    .ForMember(d => d.COL_BACK_COL_TOTAL, o => o.MapFrom(s => s["COL_BACK_COL_TOTAL"]))
                    .ForMember(d => d.COL_DATE, o => o.MapFrom(s => s.IsNull("COL_DATE") ? DateTime.Now : s["COL_DATE"]))
                    .ForMember(d => d.COL_INIDATE, o => o.MapFrom(s => s.IsNull("COL_INIDATE") ? DateTime.Now : s["COL_INIDATE"]))
                    .ForMember(d => d.COL_ENDDATE, o => o.MapFrom(s => s.IsNull("COL_ENDDATE") ? DateTime.Now : s["COL_ENDDATE"]))
                    ;
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            }

             );
            return config;
        }
        #endregion

        #region Comun

        public MapperConfiguration configAlarmsDef()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataRow, ALARMS_DEF>()
                    .ForMember(d => d.DALA_ID, o => o.MapFrom(s => s["DALA_ID"]))
                    .ForMember(d => d.DALA_DESCSHORT, o => o.MapFrom(s => s["DALA_DESCSHORT"]))
                    .ForMember(d => d.DALA_DESCLONG, o => o.MapFrom(s => s["DALA_DESCLONG"]));
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            }

             );
            return config;
        }

        public MapperConfiguration configUnits()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataRow, UNITS>()
                    .ForMember(d => d.UNI_ID, o => o.MapFrom(s => s["UNI_ID"]))
                    .ForMember(d => d.UNI_DESCSHORT, o => o.MapFrom(s => s["UNI_DESCSHORT"]))
                    .ForMember(d => d.UNI_DESCLONG, o => o.MapFrom(s => s["UNI_DESCLONG"]))
                    .ForMember(d => d.UNI_IP, o => o.MapFrom(s => s["UNI_IP"]))
                    .ForMember(d => d.UNI_VALID, o => o.MapFrom(s => s["UNI_VALID"]))
                    .ForMember(d => d.UNI_DELETED, o => o.MapFrom(s => s["UNI_DELETED"]))
                    .ForMember(d => d.UNI_DATE, o => o.MapFrom(s => s.IsNull("UNI_DATE") ? DateTime.Now : s["UNI_DATE"]));
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            }

             );
            return config;
        }
        #endregion

    }
}