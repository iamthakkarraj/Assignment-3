using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpAssignment.Database;
using CSharpAssignment.Models.Data;
using AutoMapper;

namespace CSharpAssignment.Services {

    public class CustomerService {

        private CSharpAssignmentEntities DBContext;

        /// <summary>
        /// Initialize DBContext In Constructor
        /// </summary>
        public CustomerService() {
            DBContext = new CSharpAssignmentEntities();            
        }

        /// <summary>
        /// Returns All Customer List From Database
        /// </summary>
        /// <returns>List<CustomerModel></returns>
        public List<CustomerModel> GetAllCustomers() {

            //Get Source Data Into DatabaseEntites
            List<Customer> source = DBContext.Customers.ToList();

            //Create BusinessEntites List
            List<CustomerModel> destination = new List<CustomerModel>();

            foreach(Customer customer in source) {
                //Convert DatabaseEntity Into BusinessEntity And Add Into The List
                destination.Add(ModelMapperService.Map<Customer,CustomerModel>(customer)); 
            }            

            return destination;
        }        

        /// <summary>
        /// Returns Customer From Database Matching With Given Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>CustomerModel</returns>
        public CustomerModel GetCustomer(int id) {
            Customer customer = DBContext
                                    .Customers
                                    .Where(x => x.CustomerId == id)
                                    .FirstOrDefault();
            return ModelMapperService.Map<Customer, CustomerModel>(customer);
        }

        /// <summary>
        /// Add New Customer Into Database
        /// </summary>
        /// <param name="customerModel">Object Of Customer</param>
        /// <returns>Returns Status Of The Operation in Boloean</returns>
        public bool AddCustomer(CustomerModel customerModel) {
            Customer customer = ModelMapperService.Map<CustomerModel, Customer>(customerModel);            
            DBContext.Customers.Add(customer);
            DBContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// Removes The Customer Object From The Database
        /// </summary>
        /// <param name="id">Id Of The Customer</param>
        /// <returns>Returns Status Of The Operation in Boloean</returns>
        public bool RemoveCustomer(int id) {

            DBContext
                .Customers
                .Remove(
                    DBContext
                    .Customers
                    .Where(x => x.CustomerId == id)
                    .FirstOrDefault());
            DBContext.SaveChanges();

            return true;
        }
        
        public bool UpdateCustomer(CustomerModel customerModel) {

            DBContext
                .Entry(
                    ModelMapperService
                    .Map<CustomerModel,Customer>(customerModel)
                    ).State = System.Data.Entity.EntityState.Modified;

            DBContext.SaveChanges();

            return true;
        }
    
    }

}