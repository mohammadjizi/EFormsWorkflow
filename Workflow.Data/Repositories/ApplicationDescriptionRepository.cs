using Workflow.Data.Infrastructure;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class ApplicationDescriptionRepository :  RepositoryBase<ApplicationDescription>, IApplicationDescriptionRepository
    {
        public ApplicationDescriptionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        //public ApplicationDescription GetAppDescription(string appCode)
        //{
        //  return  _context.ApplicationDescription.SingleOrDefault(a => a.AppCode == appCode);
        //}
    }
}
