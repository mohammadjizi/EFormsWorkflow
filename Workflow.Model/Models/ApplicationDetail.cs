using System;

namespace Workflow.Models
{
    public class ApplicationDetail
    {
        public  int Id { get; set; }

        public  string AppNumber { get; set; }

        public  DateTime DateCreated { get; set; }

        public ApplicationDescription AppDescription{ get; set; }

        public string RequestedBy { get; set; }
    }
}