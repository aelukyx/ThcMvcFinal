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
    public class AlquilerController : Controller
    {
        //
        // GET: /Alquiler/

        private readonly IAlquilerService service;
        public AlquilerController(IAlquilerService service)
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
            var usuarios = service.GetUsuarios();
            var clientes = service.GetClientes();
            var autos = service.GetAutos();
            var conductores = service.GetConductores();

            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "NameUser");
            ViewData["ClienteId"] = new SelectList(clientes, "Id", "NombresRazonSocial");
            ViewData["AutoId"] = new SelectList(autos, "Id", "Placa");
            ViewData["ConductorId"] = new SelectList(conductores, "Id", "NameConductor");

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
        public ActionResult Create(Alquiler alquiler)
        {
            service.Insert(alquiler);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = service.GetById(id);
            return View("edit", model);
        }

        [HttpPost]
        public ActionResult Edit(Alquiler post)
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
