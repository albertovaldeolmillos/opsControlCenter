using opsControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opsControlCenter.Helpers
{
    public class SearchPagingSort
    {
        public List<Alarmas> GetAlarms(string search, string sort, string sortdir, int skip, int pagesize, out int totalRecord)
        {
            List<Alarmas> data = new List<Alarmas>();
            totalRecord = 0;
            MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
            data = mapDataSetToModel.MapAlarms();
            if (search != "")
                data = data.Where(a => a.Tipo.Contains(search) || a.Unidad.Equals(search)).ToList();
            if (sortdir == "ASC")
            {
                if ("ALA_ID" == sort) data = data.OrderBy(x => x.ALA_ID).ToList();
                if ("ALA_UNI_ID" == sort) data = data.OrderBy(x => x.ALA_UNI_ID).ToList();
                if ("ALA_DALA_ID" == sort) data = data.OrderBy(x => x.ALA_DALA_ID).ToList();
                if ("Tipo" == sort) data = data.OrderBy(x => x.Tipo).ToList();
                if ("Unidad" == sort) data = data.OrderBy(x => x.Unidad).ToList();
                if ("ALA_INIDATE" == sort) data = data.OrderBy(x => x.ALA_INIDATE).ToList();
            }
            else
            {
                if ("ALA_ID" == sort) data = data.OrderByDescending(x => x.ALA_ID).ToList();
                if ("ALA_UNI_ID" == sort) data = data.OrderByDescending(x => x.ALA_UNI_ID).ToList();
                if ("ALA_DALA_ID" == sort) data = data.OrderByDescending(x => x.ALA_DALA_ID).ToList();
                if ("Tipo" == sort) data = data.OrderByDescending(x => x.Tipo).ToList();
                if ("Unidad" == sort) data = data.OrderByDescending(x => x.Unidad).ToList();
                if ("ALA_INIDATE" == sort) data = data.OrderByDescending(x => x.ALA_INIDATE).ToList();
            }

            
            totalRecord = data.Count;
            if (pagesize > 0)
                data = data.Skip(skip).Take(pagesize).ToList();

            return data;
        }

        public List<Recaudacion> GetRecaudacion(string search, string sort, string sortdir, int skip, int pagesize, out int totalRecord)
        {
            List<Recaudacion> data = new List<Recaudacion>();
            totalRecord = 0;
            MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
            data = mapDataSetToModel.MapRecaudacion();
            if (search != "")
                data = data.Where(a => a.COL_UNI_ID.Equals(Decimal.Parse(search))).ToList();
            if (sortdir == "ASC")
            {
                if ("COL_ID" == sort) data = data.OrderBy(x => x.COL_ID).ToList();
                if ("COL_NUM" == sort) data = data.OrderBy(x => x.COL_NUM).ToList();
                if ("COL_UNI_ID" == sort) data = data.OrderBy(x => x.COL_UNI_ID).ToList();
                if ("COL_DATE" == sort) data = data.OrderBy(x => x.COL_DATE).ToList();
                if ("COL_INIDATE" == sort) data = data.OrderBy(x => x.COL_INIDATE).ToList();
                if ("COL_ENDDATE" == sort) data = data.OrderBy(x => x.COL_ENDDATE).ToList();
                if ("COL_COIN_SYMBOL" == sort) data = data.OrderBy(x => x.COL_COIN_SYMBOL).ToList();
                if ("COL_BACK_COL_TOTAL" == sort) data = data.OrderBy(x => x.COL_BACK_COL_TOTAL).ToList();
            }
            else
            {
                if ("COL_ID" == sort) data = data.OrderByDescending(x => x.COL_ID).ToList();
                if ("COL_NUM" == sort) data = data.OrderByDescending(x => x.COL_NUM).ToList();
                if ("COL_UNI_ID" == sort) data = data.OrderByDescending(x => x.COL_UNI_ID).ToList();
                if ("COL_DATE" == sort) data = data.OrderByDescending(x => x.COL_DATE).ToList();
                if ("COL_INIDATE" == sort) data = data.OrderByDescending(x => x.COL_INIDATE).ToList();
                if ("COL_ENDDATE" == sort) data = data.OrderByDescending(x => x.COL_ENDDATE).ToList();
                if ("COL_COIN_SYMBOL" == sort) data = data.OrderByDescending(x => x.COL_COIN_SYMBOL).ToList();
                if ("COL_BACK_COL_TOTAL" == sort) data = data.OrderByDescending(x => x.COL_BACK_COL_TOTAL).ToList();
            }


            totalRecord = data.Count;
            if (pagesize > 0)
                data = data.Skip(skip).Take(pagesize).ToList();

            return data;
        }
    }
}