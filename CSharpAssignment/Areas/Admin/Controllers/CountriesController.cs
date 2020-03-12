using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpAssignment.Services;
using PagedList;

namespace CSharpAssignment.Areas.Admin.Controllers {
    public class CountriesController : Controller {

        private readonly CountryService CountryServices;

        public CountriesController() {
            this.CountryServices = new CountryService();
        }

        [OutputCache(Duration = 60)]
        // GET: Country
        public ActionResult Index(int? page) {
            return View(this.CountryServices.GetAllCountries().ToPagedList(page ?? 1,4));
        }

        [OutputCache(Duration = 60,VaryByParam = "id")]
        // GET: Country/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Country/Create  
        public ActionResult Create() {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

    }
}
