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

        /// <summary>
        /// Initialize DBContext In Constructor
        /// </summary>
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

        /// <summary>
        /// Get State List By Country Id
        /// </summary>
        /// <param name="countryId">Id Of The Country</param>
        /// <returns>List<StateModel></returns>
        public List<StateModel> GetAllStates(int countryId) {

            //Get Source Data Into DatabaseEntites
            List<State> source = DBContext
                                    .States
                                    .Where(x => x.CountryId == countryId)
                                    .ToList();

            //Create BusinessEntites List
            List<StateModel> destination = new List<StateModel>();

            foreach (State state in source) {
                //Convert DatabaseEntity Into BusinessEntity And Add Into The List
                destination.Add(ModelMapperService.Map<State, StateModel>(state));
            }

            return destination;

        }

        /// <summary>
        /// Returns State From Database Matching With Given Id
        /// </summary>
        /// <param name="id">State Id</param>
        /// <returns>State Model</returns>
        public StateModel GetState(int id) {
            return ModelMapperService
                    .Map<State, StateModel>(
                        DBContext
                        .States
                        .Where(x => x.StateId == id)
                        .FirstOrDefault());
        }

        /// <summary>
        /// Get List of SelectListItem For State DropDown
        /// </summary>
        /// <returns>List<SelectListItem></returns>
        public List<SelectListItem> GetStateDropDownList() {

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

        /// <summary>
        /// Get List of SelectListItem For State DropDown
        /// </summary>
        /// <param name="countryId">Id Of the Country</param>
        /// <param name="selectedStateId">Id Of The State Which Will Be Set To Seleted By Default</param>
        /// <returns>List<SelectListItem></returns>
        public List<SelectListItem> GetStateDropDownList(int countryId, int selectedStateId) {

            //Get All State List From Database
            List<StateModel> stateList = GetAllStates(countryId);

            //Create Empty SelectListItem List
            List<SelectListItem> stateDropDownList = new List<SelectListItem>();

            //Add Each State As A SelectListItem In Drop Down List
            foreach (StateModel state in stateList) {
                stateDropDownList.Add(new SelectListItem() {
                    Text = state.Name,
                    Value = state.StateId.ToString(),
                    Selected = (selectedStateId == state.StateId)

                });
            }

            return stateDropDownList;
        }
        
    }

}