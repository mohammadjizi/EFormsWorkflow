using System.ComponentModel.DataAnnotations;

namespace WorkflowForms.Core.Models
{
    public abstract class App
    {
        public ApplicationCustomer AppCustomer { get; set; }

        [Required]
        public ApplicationDetail AppDetail { get; set; }

    }
}
