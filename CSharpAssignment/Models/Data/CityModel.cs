using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models.Data {
    public class CityModel {

        public int CityId { get; set; }
        public string Name { get; set; }
        public Nullable<int> StateId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdateDate { get; set; }

    }
}