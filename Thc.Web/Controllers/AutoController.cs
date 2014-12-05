using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Thc.Interfaces.Services;
using Thc.Models.Models;
using Thc.Services.Services;
using Thc.DB.DB;

//Para el Path de Imagenes
using System.IO;

namespace Thc.Web.Controllers
{
    public class AutoController : Controller
    {
        //
        // GET: /Auto/

        private readonly IAutoService service;

        public AutoController(IAutoService service)
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
            var estados = service.GetEstados();
            var unidades = service.GetUnidades();

            ViewData["EstadoId"] = new SelectList(estados, "Id", "DescripcionEstado");
            ViewData["UnidadId"] = new SelectList(unidades, "Id", "DescripcionUnidad");

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
        public ActionResult Create(Auto auto)
        {
            service.Insert(auto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = service.GetById(id);
            return View("edit", model);
        }

        [HttpPost]
        public ActionResult Edit(Auto post)
        {
            if (ModelState.IsValid)
            {
                service.Update(post);
                return RedirectToAction("Index");
            }
            return View("Edit", post);
        }

        [HttpPost]
        public ActionResult UploadImage(string imageName, string contentType, string imageData)
        {
            byte[] data = Convert.FromBase64String(imageData);

            if (Request.IsAjaxRequest())
                return Content(imageData);

            return File(data, contentType, imageName);
        }

    }
}
