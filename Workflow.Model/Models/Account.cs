namespace Workflow.Models
{
    //public class Account : App
    public class Account
    {
        public int Id { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerType { get; set; }

        public string AccountType { get; set; }

        public string IBANNumber { get; set; }

        public string CurrencyCode { get; set; }

        public ApplicationCustomer AppCustomer { get; set; }

        public ApplicationDetail AppDetail { get; set; }

    }
}