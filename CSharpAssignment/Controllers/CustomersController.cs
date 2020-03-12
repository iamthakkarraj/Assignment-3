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
            return View(CustomerServices.GetAllCustomers().ToPagedList(page ?? 1, 6));
        }

        // GET: Customer/Details/5
        public JsonResult Details(int id) {
            CustomerModel customerModel = CustomerServices.GetCustomer(id);
            CityModel customerCity = new CityService().GetCity(customerModel.CityId);
            StateModel customerState = new StateService().GetState(customerCity.StateId ?? 1);
            CountryModel customerCountry = new CountryService().GetCountry(customerState.CountryId ?? 1);
            customerModel.CityName = customerCity.Name;
            customerModel.StateName = customerState.Name;
            customerModel.CountryName = customerCountry.Name;
            customerModel._CreatedDate = customerModel.CreatedDate.ToString();
            customerModel._UpdatedDate = customerModel.UpdatedDate.ToString();
            return Json(customerModel, JsonRequestBehavior.AllowGet);
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
            customerModel.CreatedDate = DateTime.Today;
            customerModel.UpdatedDate = null;
            CustomerServices.AddCustomer(customerModel);
            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id) {

            CustomerModel customerModel = CustomerServices.GetCustomer(id);
            CityModel customerCity = new CityService().GetCity(customerModel.CityId);
            StateModel customerState = new StateService().GetState(customerCity.StateId ?? 1);

            ViewBag.CityList = new CityService().GetCityDropDownList(customerState.StateId, customerCity.CityId);
            ViewBag.StateList = new StateService().GetStateDropDownList(customerState.CountryId ?? 1,customerState.StateId);
            ViewBag.CountryList = new CountryService().GetCountryDropDownList(customerState.CountryId ?? 1);

            return View(customerModel);

        }

        // POST: Customer/Edit/5        
        [HttpPost]
        public ActionResult Edit(CustomerModel customerModel) {            
            customerModel.UpdatedDate = DateTime.Today;
            CustomerServices.UpdateCustomer(customerModel);
            return RedirectToAction("Index");            
        }

        // GET: Customer/Delete/5
        [HttpGet]
        public ActionResult Delete(int id) {
            try {
                CustomerServices.RemoveCustomer(id);                
                return RedirectToAction("Index");
            } catch {
                return Json(false);
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