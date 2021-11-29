using Newtonsoft.Json;
using opsControlCenter.Helpers;
using opsControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opsControlCenter.Controllers
{
    public class TrabajoController : Controller
    {
        #region Mapa
        public ActionResult Mapa()
        {
            //FormCollection formCollection = new FormCollection();
            //formCollection.Add("search_UNI_DPUNI_ID", "1");
            //System.Reflection.PropertyInfo[] properties = typeof(UnidadesMapa).GetProperties();
            //SearchPagingSort searchPagingSort = new SearchPagingSort();
            //List<UnidadesMapa> units = searchPagingSort.Buscar<UnidadesMapa>(properties, formCollection, searchPagingSort.mapDataSetToModel.MapUnidadesMapa());
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            List<UnidadesMapa> units = searchPagingSort.mapDataSetToModel.MapUnidadesMapa();
            ViewData["UNITS"] = units;
            return View("Mapa");
        }

        public ActionResult MapaAlarmas(string id, int page = 1, string sort = "ACTIVE", string sortdir = "asc")
        {
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            int pagesize = 5;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pagesize) - pagesize;
            List<AlarmasPorUnidad> alarmas = (id == null) ? new List<AlarmasPorUnidad>() : searchPagingSort.GetAlarmasByUnitId(id, sort, sortdir, skip, pagesize, out totalRecord);
            ViewData["AlarmasPorUnidad"] = alarmas;
            ViewBag.TotalRowsAlarmas = totalRecord;
            ViewBag.Page = page;
            ViewBag.PageSizeAlarmas = pagesize;
            return Mapa();
        }

        public ActionResult MapaOperaciones(string id, int page = 1, string sort = "OPE_MOVDATE", string sortdir = "asc")
        {
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            int pagesize = 5;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pagesize) - pagesize;
            List<OperacionesPorUnidad> operaciones = (id == null) ? new List<OperacionesPorUnidad>() : searchPagingSort.GetOperacionesByUnitId(id, sort, sortdir, skip, pagesize, out totalRecord);
            ViewData["OperacionesPorUnidad"] = operaciones;
            ViewBag.TotalRowsOperaciones = totalRecord;
            ViewBag.Page = page;
            ViewBag.PageSizeOperaciones = pagesize;
            return Mapa();
        }

        //[HttpPost]
        //public ActionResult AlarmsByUnitId(string id)
        //{
        //    MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
        //    List<AlarmasPorUnidad> data = mapDataSetToModel.AlarmsHisByUnitId(id);
        //    return PartialView("AlarmasPorUnidadPartial", data);
        //}

        public ActionResult AlarmsByUnitIdJSON(string id)
        {
            MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
            var data = mapDataSetToModel.AlarmsHisByUnitId(id);
            var jsonData = Json(data);
            var list = JsonConvert.SerializeObject(data);
            return Json(data);
        }

        #endregion

        #region Alarmas
        //NOTA: Hay un problema al generalizar ya que los roles no se definen de la misma manera en todos los municipios.
        const string strRolesAlarmas = "admin, vigi";    
        [MyAuthorize(Roles = strRolesAlarmas)]
        public ActionResult Alarmas(int page = 1, string sort = "ALA_ID", string sortdir = "asc")
        {
            FormCollection formCollection = (FormCollection)Session["formCollectionAlarmas"];
            int pagesize = Int32.Parse(ConfigurationManager.AppSettings["pagesize"]);
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pagesize) - pagesize;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetAlarmas(formCollection, sort, sortdir, skip, pagesize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = formCollection;
            ViewBag.Page = page;
            ViewBag.PageSize = pagesize;
            ViewData["USR_LOGIN"] = User.Identity.Name;

            return View(data);
        }

        [MyAuthorize(Roles = strRolesAlarmas)]
        [HttpPost]
        public ActionResult AlarmasFilter(FormCollection formCollection = null)
        {
            Session["formCollectionAlarmas"] = formCollection;
            return RedirectToAction("Alarmas");
        }

        public ActionResult AlarmasPDF(string sort = "ALA_ID", string sortdir = "asc")
        {
            FormCollection formCollection = (FormCollection)Session["formCollectionAlarmas"];
            int totalRecord = 0;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetAlarmas(formCollection, sort, sortdir, 0, 0, out totalRecord);

            //Es necesario crear una PartialView para mostrar los campos que deseamos
            return new Rotativa.MVC.PartialViewAsPdf("ALarmasPartialPDF", data)
            {
                FileName = "Alarmas.pdf"
            };
        }

        public ActionResult AlarmasXLS(string sort = "ALA_ID", string sortdir = "asc")
        {
            FormCollection formCollection = (FormCollection)Session["formCollectionAlarmas"];
            int totalRecord = 0;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetAlarmas(formCollection, sort, sortdir, 0, 0, out totalRecord);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
                                            new DataColumn("Tipo"),
                                            new DataColumn("Unidad"),
                                            new DataColumn("Inicio") });
            foreach (var elem in data)
            {
                dt.Rows.Add(elem.ALA_ID, elem.DALA_DESCSHORT, elem.UNI_DESCSHORT, elem.ALA_INIDATE);
            }

            using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Inserting Tables");
                ws.Cell(1, 1).InsertTable(dt);//si en vez de dt ponemos data devuelve toda la tabla
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AlarmasXLS.xlsx");
                }
            }
        }

        /// <summary>
        /// Permite actualizar los campos de tipo texto de ALARMS
        /// </summary>
        /// <param name="id">id de la PK de la tabla actual (id registro actual) (ALA_ID,COL_ID, ...)</param>
        /// <param name="param">nombre del campo</param>
        /// <param name="original">valor original</param>
        /// <param name="value">valor obtenido</param>
        /// <returns>se devuelve el valor a mostrar</returns>
        [HttpPost]
        public ActionResult AlarmUpdateParam(int id = 1, string param = "", string original = "", string value = "")
        {
            string valueActual = "'" + value + "'";

            //aquí se guardaría en la BDs el parametro
            DataSetObject dataSetObject = new DataSetObject();
            dataSetObject.UpdateTableParam("ALARMS", param, valueActual, "ALA_ID", id.ToString());

            return Content(value);
        }

        [HttpPost]
        public ActionResult AlarmUpdateDatepickerParam(int id = 1, string param = "", string original = "", string value = "")
        {
            //aquí se guardaría en la BDs el parametro

            //nos quedamos con la fecha mas la hora original
            string datetimeActual = value + " " + original.Substring(11);

            datetimeActual = "TO_DATE('" + datetimeActual + "','dd/MM/yyyy hh24:mi:ss')";

            DataSetObject dataSetObject = new DataSetObject();
            dataSetObject.UpdateTableParam("ALARMS", param, datetimeActual, "ALA_ID", id.ToString());

            return Content(value);
        }

        [HttpPost]
        public ActionResult AlarmUpdateTimepickerParam(int id = 1, string param = "", string original = "", string value = "")
        {
            //aquí se guardaría en la BDs el parametro

            //nos quedamos con la fecha original mas la hora
            string datetimeActual = original.Substring(0,10) + " " + value;

            datetimeActual = "TO_DATE('" + datetimeActual + "','dd/MM/yyyy hh24:mi:ss')";

            DataSetObject dataSetObject = new DataSetObject();
            dataSetObject.UpdateTableParam("ALARMS", param, datetimeActual, "ALA_ID", id.ToString());

            return Content(value);
        }

        /// <summary>
        /// Permite actualizar los campos de tipo FK de ALARMS
        /// </summary>
        /// <param name="id">id de la PK de la tabla actual (id registro actual) (ALA_ID,COL_ID, ...)</param>
        /// <param name="param">nombre de la FK de la tabla (ALA_UNI_ID, ALA_DALA_ID, COL_UNI_ID, ...)</param>
        /// <param name="original">valor original</param>
        /// <param name="value">valor obtenido. Se construye en la vista normalmente con: 1- el id de la FK y 2- el valor mostrado de esa FK</param>
        /// <returns>se devuelve el valor a mostrar de la FK</returns>
        [HttpPost]
        public ActionResult AlarmUpdateSelectParam(int id = 1, string param = "", string original = "", string value = "")
        {
            var splitValue = value.Split(new[] { "___" }, StringSplitOptions.None);

            //aquí se guardaría en la BDs el parametro
            //update ALARMS set param = splitValue[0] where ALA_ID = id

            return Content(splitValue[1]);
        }



        #endregion

        #region Recaudacion

        [MyAuthorize]
        public ActionResult RecaudacionTickets()
        {
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            List<UnidadesMapa> units = searchPagingSort.mapDataSetToModel.MapUnidadesMapa();
            ViewData["UNITS"] = units;
            return View("RecaudacionTickets",units);
        }

        [MyAuthorize]
        public ActionResult Recaudacion(int page = 1, string sort = "COL_ID", string sortdir = "asc")
        {
            FormCollection formCollection = (FormCollection)Session["formCollectionRecaudacion"];
            int pagesize = Int32.Parse(ConfigurationManager.AppSettings["pagesize"]);
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pagesize) - pagesize;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetRecaudacion(formCollection, sort, sortdir, skip, pagesize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = formCollection;
            ViewBag.Page = page;
            ViewBag.PageSize = pagesize;
            ViewData["USR_LOGIN"] = User.Identity.Name;

            return View(data);
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult RecaudacionFilter(FormCollection formCollection = null)
        {
            Session["formCollectionRecaudacion"] = formCollection;
            return RedirectToAction("Recaudacion");
        }

        public ActionResult RecaudacionPDF(string sort = "COL_ID", string sortdir = "asc")
        {
            FormCollection formCollection = (FormCollection)Session["formCollectionRecaudacion"];
            int totalRecord = 0;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetRecaudacion(formCollection, sort, sortdir, 0, 0, out totalRecord);

            //Es necesario crear una PartialView para mostrar los campos que deseamos
            return new Rotativa.MVC.PartialViewAsPdf("RecaudacionPartialPDF", data)
            {
                FileName = "Recaudacion.pdf"
            };
        }

        public ActionResult RecaudacionXLS(string sort = "COL_ID", string sortdir = "asc")
        {
            FormCollection formCollection = (FormCollection)Session["formCollectionRecaudacion"];
            int totalRecord = 0;
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            var data = searchPagingSort.GetRecaudacion(formCollection, sort, sortdir, 0, 0, out totalRecord);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Id"),
                                            new DataColumn("Unidad"),
                                            new DataColumn("Número"),
                                            new DataColumn("Fecha"),
                                            new DataColumn("Inicio"),
                                            new DataColumn("Fin"),
                                            new DataColumn("Total"),
                                            new DataColumn("Moneda") });
            foreach (var elem in data)
            {
                dt.Rows.Add(elem.COL_ID, elem.UNI_DESCSHORT, elem.COL_NUM, elem.COL_DATE, elem.COL_INIDATE, elem.COL_ENDDATE, elem.COL_BACK_COL_TOTAL, elem.COL_COIN_SYMBOL);
            }

            using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Inserting Tables");
                ws.Cell(1, 1).InsertTable(dt);//si en vez de dt ponemos data devuelve toda la tabla
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RecaudacionXLS.xlsx");
                }
            }
        }

        /// <summary>
        /// Permite actualizar los campos de tipo texto de COLLECTINGS
        /// </summary>
        /// <param name="id">id de la PK de la tabla actual (id registro actual) (ALA_ID,COL_ID, ...)</param>
        /// <param name="param">nombre del campo</param>
        /// <param name="original">valor original</param>
        /// <param name="value">valor obtenido</param>
        /// <returns>se devuelve el valor a mostrar</returns>
        [HttpPost]
        public ActionResult RecaudacionUpdateParam(int id = 1, string param = "", string original = "", string value = "")
        {
            string valueActual = "'" + value + "'";

            //aquí se guardaría en la BDs el parametro
            DataSetObject dataSetObject = new DataSetObject();
            dataSetObject.UpdateTableParam("COLLECTINGS", param, valueActual, "COL_ID", id.ToString());

            return Content(value);
        }

        /// <summary>
        /// Permite actualizar los campos de tipo FK de COLLECTINGS
        /// </summary>
        /// <param name="id">id de la PK de la tabla actual (id registro actual) (ALA_ID,COL_ID, ...)</param>
        /// <param name="param">nombre de la FK de la tabla (ALA_UNI_ID, ALA_DALA_ID, COL_UNI_ID, ...)</param>
        /// <param name="original">valor original</param>
        /// <param name="value">valor obtenido. Se construye en la vista normalmente con: 1- el id de la FK y 2- el valor mostrado de esa FK</param>
        /// <returns>se devuelve el valor a mostrar de la FK</returns>
        [HttpPost]
        public ActionResult RecaudacionUpdateSelectParam(int id = 1, string param = "", string original = "", string value = "")
        {
            var splitValue = value.Split(new[] { "___" }, StringSplitOptions.None);
            string valueActual = splitValue[0];

            //aquí se guardaría en la BDs el parametro
            //update COLLECTINGS set param = splitValue[0] where COL_ID = id
            DataSetObject dataSetObject = new DataSetObject();
            dataSetObject.UpdateTableParam("COLLECTINGS", param, valueActual, "COL_ID", id.ToString());

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

        [HttpPost]
        public ActionResult RecaudacionByUnitIdJSON(string unitId)
        {
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            List<Recaudacion> recaudacionPorUnidad = searchPagingSort.mapDataSetToModel.MapRecaudacionByUnitId(unitId);
            var jsonData = Json(recaudacionPorUnidad);
            var list = JsonConvert.SerializeObject(recaudacionPorUnidad);
            return Json(recaudacionPorUnidad);
        }

        [HttpPost]
        public ActionResult CollectingnByColIdJSON(string colId)
        {
            SearchPagingSort searchPagingSort = new SearchPagingSort();
            COLLECTINGS collecting = searchPagingSort.mapDataSetToModel.MapCollecting(colId);
            var jsonData = Json(collecting);
            var list = JsonConvert.SerializeObject(collecting);
            return Json(collecting);
        }

        #endregion

    }
}