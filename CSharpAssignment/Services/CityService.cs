using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpAssignment.Database;
using CSharpAssignment.Models.Data;

namespace CSharpAssignment.Services {
    public class CityService {

        CSharpAssignmentEntities DBContext;

        public CityService() {
            DBContext = new CSharpAssignmentEntities();
        }

        /// <summary>
        /// Returns All Cities List From Database
        /// </summary>
        /// <returns>List<StateModel></returns>
        public List<CityModel> GetAllCities() {

            //Get Source Data Into DatabaseEntites
            List<City> source = DBContext.Cities.ToList();

            //Create BusinessEntites List
            List<CityModel> destination = new List<CityModel>();

            foreach(City city in source) {
                //Convert DatabaseEntity Into BusinessEntity And Add Into The List
                destination.Add(ModelMapperService.Map<City,CityModel>(city));
            }

            return destination;

        }

        public List<CityModel> GetAllCities(int id) {

            //Get Source Data Into DatabaseEntites
            List<City> source = DBContext
                                    .Cities
                                    .Where(x => x.StateId == id)
                                    .ToList();

            //Create BusinessEntites List
            List<CityModel> destination = new List<CityModel>();

            foreach (City city in source) {
                //Convert DatabaseEntity Into BusinessEntity And Add Into The List
                destination.Add(ModelMapperService.Map<City, CityModel>(city));
            }

            return destination;

        }

        /// <summary>
        /// Returns City From Database Matching With Given Id
        /// </summary>
        /// <param name="id">City Id</param>
        /// <returns>City Model</returns>
        public CityModel GetCity(int id) {            
            return ModelMapperService
                    .Map<City, CityModel>(
                        DBContext
                        .Cities
                        .Where(x => x.CityId == id)
                        .FirstOrDefault());
        }

        public List<SelectListItem> GetCityDropDownList() {

            //Get All City List From Database
            List <CityModel> cityList = GetAllCities();

            //Create Empty SelectListItem List
            List<SelectListItem> cityDropDownList = new List<SelectListItem>();

            //Add Each City As A SelectListItem In Drop Down List
            foreach (CityModel city in cityList) {
                cityDropDownList.Add(new SelectListItem() {
                    Text = city.Name,
                    Value = city.CityId.ToString()
                });
            }

            return cityDropDownList;
        }

    }
}