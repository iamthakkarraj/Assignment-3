using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models.Data {
    public class CustomerAddress { 

        public int AddressId { get; set; }

        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        [MaxLength(50)]
        public string Value { get; set; }
        public int CustomerId { get; set; }

    }
}