using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebMvcSql.Models;

namespace WebMvcSql.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            cMantenimientoArticulo item = new cMantenimientoArticulo(); 
            return View(item.RecuperarTodos());
        }
        public ActionResult Insertar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inserta(FormCollection collection)
        {
            cMantenimientoArticulo item = new cMantenimientoArticulo();
            cArticulo art = new cArticulo
            {
                Nombre = collection["nombre"],
                Apellido = collection["apellido"],
                Telefono = collection["telefono"],
                Cargo = collection["cargo"].ToString()
            };
            item.Insertar(art);
            return RedirectToAction("Index");
        }
        public ActionResult Modificar(int pCod)
        {
            cMantenimientoArticulo item = new cMantenimientoArticulo();
            cArticulo art = item.RecuperarUno(pCod);
            return View(art);
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection collection)
        {
            cMantenimientoArticulo item = new cMantenimientoArticulo();
            cArticulo art = new cArticulo
            {
                Nombre = collection["nombre"].ToString(),
                Apellido = collection["apellido"].ToString(),
                Telefono = collection["telefono"].ToString(),
                Cargo = collection["cargo"].ToString()
            };
            item.Modifica(art);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int pCod)
        {
            cMantenimientoArticulo item = new cMantenimientoArticulo();
            item.Elimina(pCod);
            return RedirectToAction("Index");
        }
    }
}