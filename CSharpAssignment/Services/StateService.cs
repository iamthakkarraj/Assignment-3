using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpAssignment.Models.Data;
using CSharpAssignment.Database;
using System.Web.Mvc;

namespace CSharpAssignment.Services {

    public class StateService {

        CSharpAssignmentEntities DBContext;

        public StateService() {
            DBContext = new CSharpAssignmentEntities();
        }

        /// <summary>
        /// Returns All States List From Database
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

        public List<StateModel> GetAllStates(int id) {

            //Get Source Data Into DatabaseEntites
            List<State> source = DBContext
                                    .States
                                    .Where(x => x.CountryId == id)
                                    .ToList();

            //Create BusinessEntites List
            List<StateModel> destination = new List<StateModel>();

            foreach (State state in source) {
                //Convert DatabaseEntity Into BusinessEntity And Add Into The List
                destination.Add(ModelMapperService.Map<State, StateModel>(state));
            }

            return destination;

        }

        public List<SelectListItem> GetStateDopDownList() {

            //Get All State List From Database
            List<StateModel> stateList = GetAllStates();

            //Create Empty SelectListItem List
            List<SelectListItem> stateDropDownList = new List<SelectListItem>();

            //Add Each State As A SelectListItem In Drop Down List
            foreach (StateModel state in stateList) {
                stateDropDownList.Add(new SelectListItem() {
                    Text = state.Name,
                    Value = state.StateId.ToString()
                });
            }

            return stateDropDownList;
        }        
    }

}