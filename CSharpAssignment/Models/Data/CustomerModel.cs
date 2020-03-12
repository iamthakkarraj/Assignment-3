using System;
using System.ComponentModel.DataAnnotations;

namespace CSharpAssignment.Models.Data {

    public class CustomerModel {

        [Display(Name = "Id")]
        public int CustomerId { get; set; }
        
        [MaxLength(56)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        [StringLength(56, ErrorMessage = Constants.ErroMessageForMaxLimit)]
        public string Name { get; set; }

        [Display(Name = "Email-Id")]                
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = Constants.ErrorMessageForEmailId)]
        public string EmailId { get; set; }

        [Display(Name = "Phone No.")]        
        [DataType(DataType.PhoneNumber)]
        [MinLength(10, ErrorMessage = Constants.ErrorMessageForPhoneNo)]
        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        public string PhoneNo { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        public string DOB { get; set; }

        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        [MaxLength(512, ErrorMessage = Constants.ErroMessageForMaxLimit)]
        public string CurrentAddress { get; set; }

        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        [MaxLength(512, ErrorMessage = Constants.ErroMessageForMaxLimit)]
        public string PermanentAddress { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        public bool IsActive { get; set; }

        [Display(Name = "Created Date")]
        public System.DateTime CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Required(ErrorMessage = Constants.ErrorMessageForRequiredField)]
        public int CityId { get; set; }
        
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string _CreatedDate { get; set; }
        public string _UpdatedDate { get; set; }
                
    }
}