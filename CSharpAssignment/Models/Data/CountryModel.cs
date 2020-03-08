using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models.Data {
    public class CountryModel {

        public int CountryId { get; set; }
        public string Name { get; set; }        
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdateDate { get; set; }

    }
}