using System;
using System.Linq;
using WorkflowForms.Core.Repositories;
using WorkflowForms.Data;

namespace WorkflowForms.Persistance.Repositories
{
    public class ApplicationDetailRepository : IApplicationDetailRepository
    {
        public ApplicationDbContext _context { get; }

        public ApplicationDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetAppNumber()
        {
            return (DateTime.Now.ToString("yy") + Convert.ToString((_context.ApplicationDetail.Max(c => c.Id) + 1)));
        }
    }
}
