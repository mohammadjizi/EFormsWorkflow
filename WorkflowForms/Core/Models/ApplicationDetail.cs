using System;
using System.ComponentModel.DataAnnotations;

namespace WorkflowForms.Core.Models
{
    public class ApplicationDetail
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        public  string AppNumber { get; set; }

        [Required]
        public  DateTime DateCreated { get; set; }

        [Required]
        public ApplicationDescription AppDescription{ get; set; }

        [Required]
        public string RequestedBy { get; set; }
    }
}