using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckerPay.Models.LoadPay;
using TruckerPay.Service;

namespace TruckerPayRedBadge.Controllers
{
    public class LoadPayController : Controller
    {
        // GET: LoadPay
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoadPayService(userId);
            var model = service.GetLoadPay();
            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoadPayCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLoadPayService();

            if (service.CreateLoadPay(model))
            {
                TempData["SaveResult"] = "Your Load Pay was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Load Pay could not be created");
            return View(model);
        }
        private LoadPayService CreateLoadPayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoadPayService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateLoadPayService();
            var model = svc.GetLoadPayById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateLoadPayService();
            var detail = service.GetLoadPayById(id);
            var model =
                new LoadPayEdit
                {
                    LoadId = detail.LoadId,
                    PayRateEmptyMiles = detail.PayRateEmptyMiles,
                    PayRateLoadedMiles = detail.PayRateLoadedMiles,
                    PerDiemRate = detail.PerDiemRate,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LoadPayEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LoadId != id)
            {
                ModelState.AddModelError("", "Id mismatch.");
                return View(model);
            }
            var service = CreateLoadPayService();
            if (service.UpdateLoadPay(model))
            {
                TempData["SaveResult"] = "Your Load pay was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Load pay could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLoadPayService();
            var model = svc.GetLoadPayById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLoadPayService();
            service.Delete(id);
            TempData["SaveResult"] = "Your Load was deleted";
            return RedirectToAction("Index");
        }
    }
}