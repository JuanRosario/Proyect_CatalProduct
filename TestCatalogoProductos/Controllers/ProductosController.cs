using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestCatalogoProductos.BLL;
using TestCatalogoProductos.Domail;
using TestCatalogoProductoss.BLL;

namespace TestCatalogoProductos.Controllers
{
    public class ProductosController : Controller
    {
        //
        // GET: /Productos/
        public ActionResult Index()
        {
            TipoProductoBLL Tipos = new TipoProductoBLL();

            return View();
        }

        public JsonResult Add_record(Productos rs)
        {
            ProductossBLL productoBll = new ProductossBLL();
            string res = string.Empty;

            try
            {

                productoBll.Save(ref rs); 

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
        public async Task<JsonResult> setDropDowwTipo()
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

        public async Task<JsonResult> Get_data()
        {

            // DataSet ds = dblayer.get_record();
            ProductossBLL productoBll = new ProductossBLL();

            var data = await productoBll.GetAll();
            List<Productos> listrs = new List<Productos>();

  
            foreach (var item in data)
            {


                listrs.Add(new Productos

                {

                    IdProductos = item.IdProductos, //Convert.ToInt32(dr["Sr_no"]),

                    Nombre = item.Nombre,

                    Descripcion = item.Descripcion,

                    Tipo = item.Tipo

                });

            }
                return Json(listrs, JsonRequestBehavior.AllowGet);            
        }
        // Display records by id

        public async Task<JsonResult> Get_databyid(int id)
        {

            // DataSet ds = dblayer.get_record();
            ProductossBLL productoBll = new ProductossBLL();

            var item = await productoBll.GetByID(id.ToString());
            List<Productos> listrs = new List<Productos>();
            TipoProductoBLL TiposBLL = new TipoProductoBLL();
           // TipoProducto Tipo = TiposBLL.GetByID(item.Tipo);
            var Tipo = TiposBLL.GetAll(true);



            listrs.Add(new Productos

            {

                IdProductos = item.IdProductos, //Convert.ToInt32(dr["Sr_no"]),

                Nombre = item.Nombre,

                Descripcion = item.Descripcion,

                Tipo = item.Tipo,
                Tipos = Tipo

            });

            return Json(listrs,JsonRequestBehavior.AllowGet);

        }

        public JsonResult update_record(Productos rs)
        {
            ProductossBLL productoBll = new ProductossBLL();
            string res = string.Empty;

            try
            {

                productoBll.Update(ref rs);

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
            ProductossBLL productoBll = new ProductossBLL();

            string res = string.Empty;

            try
            {
                productoBll.Delete(id);               
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
            TipoProductoBLL TiposBLL = new TipoProductoBLL();
           var Tipo = TiposBLL.GetByID(id.ToString());

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
