using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CSharpAssignment.Database;
using CSharpAssignment.Models.Data;

namespace CSharpAssignment.Services {

    public class CityService {

        CSharpAssignmentEntities DBContext;

        /// <summary>
        /// Initialize DBContext In Constructor
        /// </summary>
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

        /// <summary>
        /// Get List Of City By State Id
        /// </summary>
        /// <param name="id">Id Of State</param>
        /// <returns>List Of CityModel</returns>
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

        /// <summary>
        /// Get SelectListItem List For City Drop Down State Wise With
        /// Default City Selected 
        /// </summary>
        /// <param name="stateId">State Id</param>
        /// <param name="selectedCityId">Id Of Default Selected City</param>
        /// <returns>List Of SelectListItem</returns>
        public List<SelectListItem> GetCityDropDownList(int stateId, int selectedCityId) {
            //Get All City List From Database
            List<CityModel> cityList = GetAllCities(stateId);

            //Create Empty SelectListItem List
            List<SelectListItem> cityDropDownList = new List<SelectListItem>();

            //Add Each City As A SelectListItem In Drop Down List
            foreach (CityModel city in cityList) {
                cityDropDownList.Add(new SelectListItem() {
                    Text = city.Name,
                    Value = city.CityId.ToString(),
                    Selected = (selectedCityId == city.CityId)
                });
            }

            return cityDropDownList;
        }

        /// <summary>
        /// Get SelectListItem List For City Drop Down
        /// </summary>
        /// <returns>List Of SelectListItem</returns>
        public List<SelectListItem> GetCityDropDownList() {

            //Get All City List From Database
            List<CityModel> cityList = GetAllCities();

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

        /// <summary>
        /// Get SelectListItem List For City Drop Down State Wise
        /// </summary>
        /// <param name="stateId">State Id</param>
        /// <returns>List Of SelectListItem</returns>
        public List<SelectListItem> GetCityDropDownList(int stateId) {

            //Get All City List From Database
            List<CityModel> cityList = GetAllCities(stateId);

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