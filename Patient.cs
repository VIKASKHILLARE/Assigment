using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestA.Models
{
    [Table("Patient")]

    public class Patient
    {
        
        public int Id { get; set; }
   
        public string Photo { get; set; }

        [Required(ErrorMessage = "Please Enter Patient Full Name...")]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Select the Gender...")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Please Enter Case type...")]
        [Display(Name = "CaseType")]
        public string CaseType { get; set; }

        [Required(ErrorMessage = "Please Enter Police  Enquiry Remark...")]
        [Display(Name = "Enquiry Remark")]
        public string EnquiryRemark { get; set; }


        [Required(ErrorMessage = "Please Enter Present Address...")]
        [Display(Name = "PresentAddress")]
        public string PresentAddresss { get; set; }


        [Required(ErrorMessage = "Please Enter Permanent Address...")]
        [Display(Name = "PermanentAddress")]
        public string PermanentAddresss { get; set; }





    }
}
