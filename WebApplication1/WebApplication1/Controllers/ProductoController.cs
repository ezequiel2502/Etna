using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListProductoViewModels> lst;
            using (CarritoEntities db = new CarritoEntities())
            {
                lst = (from d in db.Producto
                       select new ListProductoViewModels
                       {
                           id = d.id,
                           nombre = d.nombre,
                           descripcion = d.descripcion,
                           precio = (double)d.precio
                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ProductoViewModel model)
        {
            try {
            if(ModelState.IsValid)
                {
                    using (CarritoEntities db = new CarritoEntities())
                    {
                        var oProducto = new Producto();
                        oProducto.id = model.id;
                        oProducto.nombre = model.nombre;
                        oProducto.descripcion = model.descripcion;
                        oProducto.precio = model.precio;

                        db.Producto.Add(oProducto);
                        db.SaveChanges();
                    }
                    return Redirect("/Producto");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            ProductoViewModel model = new ProductoViewModel();
            using (CarritoEntities db = new CarritoEntities())
            {
                var oProducto = db.Producto.Find(id);
                model.nombre = oProducto.nombre;
                model.descripcion = oProducto.descripcion;
                model.precio = (double)oProducto.precio;
                model.id = oProducto.id;

            }
                return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CarritoEntities db = new CarritoEntities())
                    {
                        var oProducto = db.Producto.Find(model.id);
                        oProducto.id = model.id;
                        oProducto.nombre = model.nombre;
                        oProducto.descripcion = model.descripcion;
                        oProducto.precio = model.precio;

                        db.Entry(oProducto).State=System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Producto");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            ProductoViewModel model = new ProductoViewModel();
            using (CarritoEntities db = new CarritoEntities())
            {
                var oProducto = db.Producto.Find(id);
                db.Producto.Remove(oProducto);
                db.SaveChanges();
            
                }
            return Redirect("/Producto");
        }
    }
}