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
        public MapperConfiguration configAlarmas()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataRow, Alarmas>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s["Id"]))
                    .ForMember(d => d.IdTipo, o => o.MapFrom(s => s["IdTipo"]))
                    .ForMember(d => d.Tipo, o => o.MapFrom(s => s["Tipo"]))
                    .ForMember(d => d.Unidad, o => o.MapFrom(s => s["Unidad"]))
                    .ForMember(d => d.Inicio, o => o.MapFrom(s => s.IsNull("Inicio") ? DateTime.Now : s["Inicio"]));
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            }

             );
            return config;
        }

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
    }
}