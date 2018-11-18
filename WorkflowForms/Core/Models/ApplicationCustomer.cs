using System.ComponentModel.DataAnnotations;

namespace WorkflowForms.Core.Models
{
    public class ApplicationCustomer
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [StringLength(13,MinimumLength = 13,ErrorMessage = "Account Number should be 13 digit")]
        [RegularExpression("(^[0-9]*$)", ErrorMessage = "Please enter valid Number")]
        public  string AccountNumber { get; set; }

        [Required]
        public  string IDNumber { get; set; }

        [Required]
        public  string IDType { get; set; }

        public  string MobileNumber { get; set; }

        [Required]
        public  string FullName { get; set; }
    }
}