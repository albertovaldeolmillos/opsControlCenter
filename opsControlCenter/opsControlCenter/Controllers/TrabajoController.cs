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
        #region Alarmas
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

        /// <summary>
        /// Permite actualizar los campos de tipo texto de ALARMS
        /// </summary>
        /// <param name="id">id de la PK de la tabla actual (id registro actual) (ALA_ID,COL_ID, ...)</param>
        /// <param name="param">nombre del campo</param>
        /// <param name="value">valor obtenido</param>
        /// <returns>se devuelve el valor a mostrar</returns>
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

        /// <summary>
        /// Permite actualizar los campos de tipo FK de ALARMS
        /// </summary>
        /// <param name="id">id de la PK de la tabla actual (id registro actual) (ALA_ID,COL_ID, ...)</param>
        /// <param name="param">nombre de la FK de la tabla (ALA_UNI_ID, ALA_DALA_ID, COL_UNI_ID, ...)</param>
        /// <param name="value">valor obtenido. Se construye en la vista normalmente con: 1- el id de la FK y 2- el valor mostrado de esa FK</param>
        /// <returns>se devuelve el valor a mostrar de la FK</returns>
        [HttpPost]
        public ActionResult AlarmUpdateSelectParam(int id = 1, string param = "", string value = "")
        {
            var splitValue = value.Split(new[] { "___" }, StringSplitOptions.None);

            //aquí se guardaría en la BDs el parametro
            //update ALARMS set param = splitValue[0] where ALA_ID = id

            return Content(splitValue[1]);
        }
        #endregion

        #region Recaudacion
        public ActionResult Recaudacion(int page = 1, string sort = "COL_ID", string sortdir = "asc", string search = "")
        {
            int pagesize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pagesize) - pagesize;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetRecaudacion(search, sort, sortdir, skip, pagesize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;
            ViewBag.Page = page;

            return View(data);
        }

        /// <summary>
        /// Permite actualizar los campos de tipo FK de COLLECTINGS
        /// </summary>
        /// <param name="id">id de la PK de la tabla actual (id registro actual) (ALA_ID,COL_ID, ...)</param>
        /// <param name="param">nombre de la FK de la tabla (ALA_UNI_ID, ALA_DALA_ID, COL_UNI_ID, ...)</param>
        /// <param name="value">valor obtenido. Se construye en la vista normalmente con: 1- el id de la FK y 2- el valor mostrado de esa FK</param>
        /// <returns>se devuelve el valor a mostrar de la FK</returns>
        [HttpPost]
        public ActionResult RecaudacionUpdateSelectParam(int id = 1, string param = "", string value = "")
        {
            var splitValue = value.Split(new[] { "___" }, StringSplitOptions.None);

            //aquí se guardaría en la BDs el parametro
            //update COLLECTINGS set param = splitValue[0] where COL_ID = id

            return Content(splitValue[1]);
        }
        #endregion

        #region comun
        [HttpPost]
        public ActionResult UnitsJSON()
        {
            MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
            var data = mapDataSetToModel.MapUnits();
            var jsonData = Json(data);
            var list = JsonConvert.SerializeObject(data);
            return Json(data);
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
        #endregion

    }
}