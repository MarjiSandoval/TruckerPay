﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using TruckerPay.Models.Load;

namespace TruckerPayRedBadge.Controllers
{
    public class LoadController : Controller
    {
        // GET: Load
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoadService(userId);
            var model = service.GetLoads();

            return View();
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoadCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLoadService();

            if (service.LoadCreate(model))
            {
                TempData["SaveResult"] = "Your Load was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Load could not be created.");
            return View(model);
        }
        private LoadService CreateLoadService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoadService(userId);
            return service;
        }
        public ActionResult Edit(int id)
        {
            var service = CreateLoadService();
            var detail = service.GetLoadById(id);
            var model =
                new LoadEdit
                {
                    LoadId = detail.LoadId,
                    ShipperName = detail.ShipperName,
                    ShipperLocation = detail.ShipperLocation,
                    ShipperPhone = detail.ShipperPhone,
                    ReceiverName = detail.ReceiverName,
                    ReceiverLocation = detail.ReceiverLoaction,
                    ReceiverPhone = detail.ReceiverPhone,
                    EmptyMiles = detail.EmptyMiles,
                    LoadedMiles = detail.LoadedMiles
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LoadEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.LoadId != id)
            {
                ModelState.AddModelError("", "Id mismatch.");
                return View(model);
            }
            var service = CreateLoadService();
            if (service.UpdateLoad(model))
            {
                TempData["SaveResult"] = "Your Load was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Load could not be updated.");
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLoad(int id)
        {
            var service = CreateLoadService();
            service.DeleteLoad(id);
            TempData["SaveResult"] = "Your Load was deleted";
            return RedirectToAction("Index");
        }
    }
}