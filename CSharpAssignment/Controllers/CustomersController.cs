using PagedList;
using System.Web.Mvc;
using CSharpAssignment.Services;
using CSharpAssignment.Models.Data;
using System;

namespace CSharpAssignment.Controllers {
    public class CustomersController : Controller {

        private readonly CustomerService CustomerServices;

        public CustomersController() {
            CustomerServices = new CustomerService();
        }

        // GET: Customer
        public ActionResult Index(int? page) {
            return View(CustomerServices.GetAllCustomers().ToPagedList(page ?? 1, 4));
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id) {
            return View(CustomerServices.GetCustomer(id));
        }

        // GET: Customer/Create
        public ActionResult Create() {
            CustomerModel customerModel = new CustomerModel();            
            customerModel.CreatedDate = DateTime.Today;
            ViewBag.CountryList = new CountryService().GetCountryDropDownList();
            return View(customerModel);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customerModel) {
            CustomerServices.AddCustomer(customerModel);
            return RedirectToAction("Index");
            try {                 
            }
            catch(Exception e) {
                ViewBag.CountryList = new CountryService().GetCountryDropDownList();                
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id) {
            return View(CustomerServices.GetCustomer(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerModel customerModel) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id) {
            return View(CustomerServices.GetCustomer(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(CustomerModel customerModel) {
            try {
                CustomerServices.RemoveCustomer(customerModel.CustomerId);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public JsonResult GetStateList(int id) {
            return Json(new StateService().GetAllStates(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCityList(int id) {
            return Json(new CityService().GetAllCities(id), JsonRequestBehavior.AllowGet);
        }

    }
}