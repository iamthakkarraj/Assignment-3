using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models.Data {
    public class Customer {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public System.DateTime DOB { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int CityId { get; set; }
    }
}