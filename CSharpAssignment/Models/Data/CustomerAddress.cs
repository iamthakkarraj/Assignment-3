using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models.Data {
    public class CustomerAddress {

        [Required]
        public int AddressId { get; set; }
        public string Value { get; set; }
        public int CustomerId { get; set; }
    }
}