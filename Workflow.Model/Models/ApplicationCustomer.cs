using System.ComponentModel.DataAnnotations;

namespace Workflow.Models
{
    public class ApplicationCustomer
    {
        public  int Id { get; set; }

        [StringLength(13,MinimumLength = 13,ErrorMessage = "Account Number should be 13 digit")]
        [RegularExpression("(^[0-9]*$)", ErrorMessage = "Please enter valid Number")]
        public  string AccountNumber { get; set; }

        public  string IDNumber { get; set; }

        public  string IDType { get; set; }

        public  string MobileNumber { get; set; }

        public  string FullName { get; set; }
    }
}