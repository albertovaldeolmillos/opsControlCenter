using opsControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Reflection;

namespace opsControlCenter.Helpers
{
    public class SearchPagingSort
    {
        MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
        public List<Alarmas> GetAlarmas(FormCollection search, string sort, string sortdir, int skip, int pagesize, out int totalRecord)
        {
            List<Alarmas> data = new List<Alarmas>();
            totalRecord = 0;
            
            data = mapDataSetToModel.MapAlarmas();

            //if (search != "")
            //    data = data.Where(a => a.DALA_DESCSHORT.Contains(search) || a.UNI_DESCSHORT.Equals(search)).ToList();
            var properties = typeof(Alarmas).GetProperties();
            data = Buscar<Alarmas>(properties, search, data);

            var property = typeof(Alarmas).GetProperty(sort);
            if (sortdir == "ASC" || sortdir == "asc" || sortdir == "Ascending") data = data.OrderBy(x => property.GetValue(x, null)).ToList();
            else data = data.OrderByDescending(x => property.GetValue(x, null)).ToList();
            
            totalRecord = data.Count;
            if (pagesize > 0)
                data = data.Skip(skip).Take(pagesize).ToList();

            return data;
        }

        public List<Recaudacion> GetRecaudacion(FormCollection search, string sort, string sortdir, int skip, int pagesize, out int totalRecord)
        {
            List<Recaudacion> data = new List<Recaudacion>();
            totalRecord = 0;

            data = mapDataSetToModel.MapRecaudacion();
            decimal res = 0;

            //if (search != "" && Decimal.TryParse(search, out res))
            //    data = data.Where(a => a.COL_UNI_ID.Equals(Decimal.Parse(search))).ToList();
            var properties = typeof(Recaudacion).GetProperties();
            data = Buscar<Recaudacion>(properties, search, data);

            var property = typeof(Recaudacion).GetProperty(sort);
            if (sortdir == "ASC" || sortdir == "asc" || sortdir == "ascending") data = data.OrderBy(x => property.GetValue(x, null)).ToList();
            else data = data.OrderByDescending(x => property.GetValue(x, null)).ToList();

            totalRecord = data.Count;
            if (pagesize > 0)
                data = data.Skip(skip).Take(pagesize).ToList();

            return data;
        }

        #region general

        List<T> Buscar<T>(PropertyInfo[] properties, FormCollection search, List<T> data)
        {
            foreach (var prop in properties)
            {
                var nombre = prop.Name;
                //var propert = typeof(Alarmas).GetProperty(nombre);
                if (search != null)
                {
                    var valorCampo = search["search_" + nombre];
                    if (valorCampo != null && valorCampo != "")
                    {
                        var tipoNombre = prop.PropertyType.Name;
                        var tipo = System.Type.GetTypeCode(prop.PropertyType);
                        //var caso1 = data[0].GetType().GetProperty(nombre).GetValue(data[0], null);
                        if (tipo == TypeCode.Decimal || tipo == TypeCode.Double || tipo == TypeCode.Int16 || tipo == TypeCode.Int32 || tipo == TypeCode.Int64)
                            data = data.Where(a => (a.GetType().GetProperty(nombre).GetValue(a, null).ToString()).Equals(valorCampo)).ToList();
                        else if (tipo == TypeCode.DateTime || prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                        {
                            valorCampo = valorCampo.Trim(' ');
                            string[] fechas = valorCampo.Split('-');
                            string[] fechaIniStr = fechas[0].Split('/');
                            string[] fechaFinStr = fechas[1].Split('/');
                            DateTime fechaIni = new DateTime(Convert.ToInt32(fechaIniStr[2]), Convert.ToInt32(fechaIniStr[1]), Convert.ToInt32(fechaIniStr[0]));
                            DateTime fechaFin = new DateTime(Convert.ToInt32(fechaFinStr[2]), Convert.ToInt32(fechaFinStr[1]), Convert.ToInt32(fechaFinStr[0]));
                            data = data.Where(a => (DateTime)(a.GetType().GetProperty(nombre).GetValue(a, null)) > fechaIni)
                                .Where(a => (DateTime)(a.GetType().GetProperty(nombre).GetValue(a, null)) < fechaFin).ToList();
                        }
                        else
                            data = data.Where(a => (a.GetType().GetProperty(nombre).GetValue(a, null).ToString()).Contains(valorCampo)).ToList();
                    }
                }
            }
            return data;
        }

        #endregion
    }
}