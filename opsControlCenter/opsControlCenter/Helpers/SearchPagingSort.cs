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
            data = data.Where(a => a.Tipo.Contains(search) || a.Unidad.Equals(search)).ToList();
            if (sortdir == "ASC")
            {
                if ("Id" == sort) data = data.OrderBy(x => x.Id).ToList();
                if ("Tipo" == sort) data = data.OrderBy(x => x.Tipo).ToList();
                if ("Unidad" == sort) data = data.OrderBy(x => x.Unidad).ToList();
                if ("Inicio" == sort) data = data.OrderBy(x => x.Inicio).ToList();
            }
            else
            {
                if ("Id" == sort) data = data.OrderByDescending(x => x.Id).ToList();
                if ("Tipo" == sort) data = data.OrderByDescending(x => x.Tipo).ToList();
                if ("Unidad" == sort) data = data.OrderByDescending(x => x.Unidad).ToList();
                if ("Inicio" == sort) data = data.OrderByDescending(x => x.Inicio).ToList();
            }

            
            totalRecord = data.Count;
            if (pagesize > 0)
                data = data.Skip(skip).Take(pagesize).ToList();

            return data;
        }
    }
}