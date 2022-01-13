using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckerPay.Models.WeeklyPay;
using TruckerPay.Service;

namespace TruckerPayRedBadge.Controllers
{
    public class WeeklyPayController : Controller
    {
        // GET: WeeklyPay
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeeklyPayService(userId);
            var model = service.GetWeeklyPay();
            return View();
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeeklyPayCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWeeklyPayService();

            if (service.CreateWeeklyPay(model))
            {
                TempData["SaveResult"] = "Your Weekly Pay was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Weekly Pay could not be created.");
            return View(model);
        }
        private WeeklyPayService CreateWeeklyPayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeeklyPayService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateWeeklyPayService();
            var model = svc.GetWeeklyPayById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateWeeklyPayService();
            var detail = service.GetWeeklyPayById(id);
            var model =
                new WeeklyPayEdit
                {
                    PayDate = detail.PayDate,
                    LoadId = detail.LoadId,
                    EmptyMiles = detail.EmptyMiles,
                    LoadedMiles = detail.LoadedMiles
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WeeklyPayEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LoadId != id)
            {
                ModelState.AddModelError("", "Id mismatch.");
                return View(model);
            }
            var service = CreateWeeklyPayService();
            if (service.UpdateWeeklyPay(model))
            {
                TempData["SaveResult"] = "Your Weekly pay was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Weekly pay could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWeeklyPayService();
            var model = svc.GetWeeklyPayById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWeeklyPayService();
            service.Delete(id);
            TempData["SaveResult"] = "Your Load was deleted";
            return RedirectToAction("Index");
        }
    }
}