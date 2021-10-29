using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestCatalogoProductos.BLL;
using TestCatalogoProductos.Domail;

namespace TestCatalogoProductos.Controllers
{
    public class TipoProductoController : Controller
    {
        //
        // GET: /TipoProducto/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Add_record(TipoProducto rs)
        {
            TipoProductoBLL TipoProductoBll = new TipoProductoBLL();
            string res = string.Empty;

            try
            {

                TipoProductoBll.Save(ref rs);

                res = "Inserted";

            }

            catch (Exception)
            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }
        public ActionResult Show_data()
        {

            return View();

        }
        public async Task<JsonResult> Get_data()
        {


            TipoProductoBLL TipoProductoBll = new TipoProductoBLL();


            var data = await TipoProductoBll.GetAll();
            List<TipoProducto> listrs = new List<TipoProducto>();


            foreach (var item in data)
            {

                listrs.Add(new TipoProducto

                {

                    IdTipoProductos = item.IdTipoProductos, //Convert.ToInt32(dr["Sr_no"]),

                    Nombre = item.Nombre,

                    Fragil = item.Fragil


                });

            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        // Display records by id

        public async Task<JsonResult> Get_databyid(int id)
        {

            // DataSet ds = dblayer.get_record();
            TipoProductoBLL TipoProductoBll = new TipoProductoBLL();

            var item = await TipoProductoBll.GetByID(id.ToString());
            List<TipoProducto> listrs = new List<TipoProducto>();


            listrs.Add(new TipoProducto

            {

                IdTipoProductos = item.IdTipoProductos, 

                Nombre = item.Nombre,

                Fragil = item.Fragil

            });

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

        public JsonResult update_record(TipoProducto rs)
        {
            TipoProductoBLL TipoProductoBll = new TipoProductoBLL();

            string res = string.Empty;

            try
            {

                TipoProductoBll.Update(ref rs);

                res = "Updated";

            }

            catch (Exception)
            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

        // Delete record

        public JsonResult delete_record(int id)
        {
            string res = string.Empty;
            TipoProductoBLL TipoProductoBll = new TipoProductoBLL();

            try
            {
                TipoProductoBll.Delete(id);
                res = "data deleted";
            }

            catch (Exception)
            {
                res = "failed";
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Productos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Productos/Edit/5

        public ActionResult update_data(int id)
        {

            return View();

        }

        //
        // POST: /Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}