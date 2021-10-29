using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestCatalogoCategorias.BLL;
using TestCatalogoProductos.Domail;

namespace TestCatalogoProductos.Controllers
{
    public class CategoriasController : Controller
    {
        //
        // GET: /Categorias/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Add_record(Categorias rs)
        {
            CategoriasBLL categoriaBll = new CategoriasBLL();
            string res = string.Empty;

            try
            {

                categoriaBll.Save(ref rs); 

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


            CategoriasBLL CategoriasBll = new CategoriasBLL();

            var data = await CategoriasBll.GetAll();
            List<Categorias> listrs = new List<Categorias>();


            foreach (var item in data)
            {

                listrs.Add(new Categorias

                {

                    IDCategorias = item.IDCategorias, //Convert.ToInt32(dr["Sr_no"]),

                    Nombre = item.Nombre,

                    Descripcion = item.Descripcion,
                    Tipo = item.Tipo,

                    CategoriaDepende = item.CategoriaDepende


                });

            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        // Display records by id

        public async Task<JsonResult> Get_databyid(int id)
        {

            // DataSet ds = dblayer.get_record();
            CategoriasBLL CategoriasBll = new CategoriasBLL();

            var item = await CategoriasBll.GetByID(id.ToString());
            List<Categorias> listrs = new List<Categorias>();


            listrs.Add(new Categorias

            {

                IDCategorias = item.IDCategorias, 

                Nombre = item.Nombre,
                Descripcion = item.Descripcion,
                Tipo = item.Tipo,
                CategoriaDepende = item.CategoriaDepende,

               

            });

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

        public JsonResult update_record(Categorias rs)
        {
            CategoriasBLL CategoriasBll = new CategoriasBLL();

            string res = string.Empty;

            try
            {

                CategoriasBll.Update(ref rs);

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
            CategoriasBLL CategoriasBll = new CategoriasBLL();

            try
            {
                CategoriasBll.Delete(id);
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