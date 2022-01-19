using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using TruckerPay.Models.Load;
using TruckerPay.Service;

namespace TruckerPayRedBadge.Controllers
{
    [Authorize]
    public class LoadController : Controller
    {
        // GET: Load
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoadService(userId);
            var model = service.GetLoads();

            return View(model);
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

            if (service.CreateLoad(model))
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
        public ActionResult Details(int id)
        {
            var svc = CreateLoadService();
            var model = svc.GetLoadById(id);

            return View(model);
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
                    ReceiverName = detail.ReceiverName,
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
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLoadService();
            var model = svc.GetLoadById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLoadService();
            service.Delete(id);
            TempData["SaveResult"] = "Your Load was deleted";
            return RedirectToAction("Index");
        }

        
    }
}