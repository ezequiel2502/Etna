using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private CarritoViewModels model = new CarritoViewModels();
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
        private CarritoEntities db = new CarritoEntities();
       private List<CarritoViewModels> compras = new List<CarritoViewModels>();
        public ActionResult Agrega( ProductoViewModel model)
        {
            
            if (Session["Carrito"] == null)
            {

                compras.Add(new CarritoViewModels(db.Producto.Find(model.id),1));
                Session["Carrito"] = compras;
            }
            else
            {
                compras = (List<CarritoViewModels>)Session["Carrito"];
                int indexExistente = getIndex(model.id);
                if (indexExistente == -1)
                {
                    compras.Add(new CarritoViewModels(db.Producto.Find(model.id), 1));
                    Session["Carrito"] = compras;
                }
                else
                {
                    compras[indexExistente].Cantidad++;
                }
            }
            return View("Agrega");
        }
        public ActionResult MostrarCarrito()
        {
            List<CarritoViewModels> listaCarrito = compras;
            return View( listaCarrito);
        }
        private int getIndex(int id)
        {
            List<CarritoViewModels> compras = (List<CarritoViewModels>)Session["Carrito"];
            for(int i=0; i< compras.Count; i++)
            {
                if (compras[i].Producto.id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult Delete(int id)
        { 
            compras= (List<CarritoViewModels>)Session["Carrito"];
            compras.RemoveAt(getIndex(id));
            return View("mostrarCarrito");
        }

    }
}