using System.ComponentModel.DataAnnotations;

namespace WorkflowForms.Core.Models
{
    public class ApplicationDescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public  string AppCode { get; set; }

        [Required]
        public  string AppType { get; set; }     

    }
}