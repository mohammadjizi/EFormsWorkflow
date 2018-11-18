using System.ComponentModel.DataAnnotations;

namespace WorkflowForms.Core.Models
{
    public class EquationCustomer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public  string FirstName { get; set; }

        [Required]
        public  string LastName { get; set; }

        [Required]
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