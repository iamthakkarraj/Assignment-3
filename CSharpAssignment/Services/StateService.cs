using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpAssignment.Models.Data;
using CSharpAssignment.Database;

namespace CSharpAssignment.Services {

    public class StateService {
        CSharpAssignmentEntities DBContext;

        public StateService() {
            DBContext = new CSharpAssignmentEntities();
        }

        /// <summary>
        /// Returns All Cities List From Database
        /// </summary>
        /// <returns>List<StateModel></returns>
        public List<StateModel> GetAllStates() {

            //Get Source Data Into DatabaseEntites
            List<State> source = DBContext.States.ToList();

            //Create BusinessEntites List
            List<StateModel> destination = new List<StateModel>();

            foreach (State state in source) {
                //Convert DatabaseEntity Into BusinessEntity And Add Into The List
                destination.Add(ModelMapperService.Map<State, StateModel>(state));
            }

            return destination;

        }
    }

}