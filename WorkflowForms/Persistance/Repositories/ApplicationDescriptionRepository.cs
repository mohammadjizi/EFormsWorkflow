using System.Linq;
using WorkflowForms.Core.Models;
using WorkflowForms.Core.Repositories;
using WorkflowForms.Data;

namespace WorkflowForms.Persistance.Repositories
{
    public class ApplicationDescriptionRepository : IApplicationDescriptionRepository
    {
        public ApplicationDbContext _context { get; }

        public ApplicationDescriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDescription GetAppDescription(string appCode)
        {
          return  _context.ApplicationDescription.SingleOrDefault(a => a.AppCode == appCode);
        }
    }
}
