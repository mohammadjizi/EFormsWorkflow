using System.ComponentModel.DataAnnotations;

namespace WorkflowForms.Core.Models
{
    public class Account : App
    {
        [Key]
        public int Id { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerType { get; set; }

        public string AccountType { get; set; }

        public string IBANNumber { get; set; }

        public string CurrencyCode { get; set; }

    }
}