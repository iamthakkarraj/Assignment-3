using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models.Data {
    public class CustomerModel {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public System.DateTime DOB { get; set; }

        [Display(Name = "Status")]
        public Nullable<bool> IsActive { get; set; }

        [Display(Name = "Created Date")]
        public System.DateTime CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public System.DateTime UpdatedDate { get; set; }
        public int CityId { get; set; }
    }
}