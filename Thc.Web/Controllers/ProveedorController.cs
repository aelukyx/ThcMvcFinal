using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Thc.Interfaces.Services;
using Thc.Models.Models;
using Thc.Services.Services;


namespace Thc.Web.Controllers
{
    public class ProveedorController : Controller
    {
        //
        // GET: /Proveedor/

        private readonly IProveedorService service;

        public ProveedorController(IProveedorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View("Index", service.All());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var ciudades = service.GetCiudades();

            ViewData["CiudadId"] = new SelectList(ciudades, "Id", "NameCiudad");

            return View("Create");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            return View("Details", service.GetById(id));
        }


        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                service.Insert(proveedor);
                return RedirectToAction("Index");
            }
            return View("Create", proveedor);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = service.GetById(id);
            return View("edit", model);
        }

        [HttpPost]
        public ActionResult Edit(Proveedor post)
        {
            if (ModelState.IsValid)
            {
                service.Update(post);
                return RedirectToAction("Index");
            }
            return View("Edit", post);
        }

    }
}
