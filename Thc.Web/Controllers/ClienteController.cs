using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Thc.Interfaces.Services;
using Thc.Models.Models;
using Thc.Services.Services;
using Thc.DB.DB;

using System.ComponentModel.DataAnnotations;

namespace Thc.Web.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        private readonly ThcEntities entities;

        private readonly IClienteService service;
        public ClienteController(IClienteService service)
        {
            this.service = service;
            this.entities = new ThcEntities();
        }


        [HttpGet]
        public ViewResult Index()
        {
            return View("Index", service.All());
        }

        [HttpGet]
        public ActionResult Create()
        {
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
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                service.Insert(cliente);
                return RedirectToAction("Index");
            }
            return View("Create", cliente);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = service.GetById(id);
            return View("edit", model);
        }

        [HttpPost]
        public ActionResult Edit(Cliente post)
        {
            if (ModelState.IsValid)
            {
                service.Update(post);
                return RedirectToAction("Index");
            }
            return View("Edit", post);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = entities.Clientes.Find(id);
            entities.Clientes.Remove(model);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
