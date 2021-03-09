using Newtonsoft.Json;
using opsControlCenter.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opsControlCenter.Controllers
{
    public class TrabajoController : Controller
    {
        // GET: Trabajo
        public ActionResult Alarmas(int page = 1, string sort = "ID", string sortdir = "asc", string search = "")
        {
            int pagesize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pagesize) - pagesize;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetAlarms(search, sort, sortdir, skip, pagesize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;
            ViewBag.Page = page;

            return View(data);
        }

        [HttpPost]
        public ActionResult AlarmUpdateParam(int id = 1, string param = "Tipo", string value = "")
        {
            //aquí se guardaría en la BDs el parametro

            return Content(value);
        }

        [HttpPost]
        public ActionResult AlarmUpdateDatepickerParam(int id = 1, string param = "Tipo", string value = "")
        {
            //aquí se guardaría en la BDs el parametro

            return Content(value);
        }

        [HttpPost]
        public ActionResult AlarmUpdateSelectAlarmsDefParam(int id = 1, string param = "Tipo", string value = "")
        {
            //aquí se guardaría en la BDs el parametro

            var splitValue = value.Split(new[] { "___" }, StringSplitOptions.None);
            return Content(splitValue[1]);
        }

        [HttpPost]
        public ActionResult AlarmsDefJSON()
        {
            MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
            var data = mapDataSetToModel.MapAlarmsDef();
            var jsonData = Json(data);
            var list = JsonConvert.SerializeObject(data);
            return Json(data);
        }

        [HttpPost]
        public ActionResult AlarmUpdateSelectUnitsParam(int id = 1, string param = "Tipo", string value = "")
        {
            //aquí se guardaría en la BDs el parametro

            var splitValue = value.Split(new[] { "___" }, StringSplitOptions.None);
            return Content(splitValue[1]);
        }

        [HttpPost]
        public ActionResult UnitsJSON()
        {
            MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
            var data = mapDataSetToModel.MapUnits();
            var jsonData = Json(data);
            var list = JsonConvert.SerializeObject(data);
            return Json(data);
        }
    }
}