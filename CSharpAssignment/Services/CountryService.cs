using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpAssignment.Database;
using CSharpAssignment.Models.Data;

namespace CSharpAssignment.Services {
    public class CountryService {

        CSharpAssignmentEntities DBContext;

        public CountryService() {
            DBContext = new CSharpAssignmentEntities();
        }

        /// <summary>
        /// Returns All Country List From Database
        /// </summary>
        /// <returns>List<CountryModel></returns>
        public List<CountryModel> GetAllCountries() {

            //Get Source Data Into DatabaseEntites
            List<Country> source = DBContext.Countries.ToList();

            //Create BusinessEntites List
            List<CountryModel> destination = new List<CountryModel>();

            foreach (Country country in source) {
                //Convert DatabaseEntity Into BusinessEntity And Add Into The List
                destination.Add(ModelMapperService.Map<Country, CountryModel>(country));
            }

            return destination;

        }

    }
}