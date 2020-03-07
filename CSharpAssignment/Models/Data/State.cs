using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models.Data {
    public class State {
        public int StateId { get; set; }
        public string Name { get; set; }
        public Nullable<int > CountryId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    }
}