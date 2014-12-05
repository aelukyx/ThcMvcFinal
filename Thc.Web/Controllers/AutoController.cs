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

        //public FileContentResult GetImage(Int32 CategoryID)
        //{
        //    Auto cat = entities.Autos.FirstOrDefault(c => c.Id == CategoryID);

        //    if (cat != null)
        //    {

        //        string type = string.Empty;
        //        if (!string.IsNullOrEmpty(cat.ImageMimeType))
        //        {
        //            type = cat.ImageMimeType;
        //        }
        //        else
        //        {
        //            type = "image/jpeg";
        //        }

        //        return File(cat.Picture, type);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        //[HttpPost]
        //public ActionResult SendImage(HttpPostedFileBase img)
        //{
        //    var data = new byte[img.ContentLength];
        //    img.InputStream.Read(data, 0, img.ContentLength);
        //    var path = ControllerContext.HttpContext.Server.MapPath("/");
        //    var filename = Path.Combine(path, Path.GetFileName(img.FileName));
        //    System.IO.File.WriteAllBytes(Path.Combine(path, filename), data);
        //    ViewBag.ImageUploaded = filename;
        //    return View("Index");
        //}

        //public ActionResult Preview(string file)
        //{
        //    var path = ControllerContext.HttpContext.Server.MapPath("/");
        //    if (System.IO.File.Exists(Path.Combine(path, file)))
        //    {
        //        return File(Path.Combine(path, file), "image/jpeg");
        //    }
        //    return new HttpNotFoundResult();
        //}
    }
}
