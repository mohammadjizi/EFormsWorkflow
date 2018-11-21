using Workflow.Data.Infrastructure;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class ApplicationDetailRepository : RepositoryBase<ApplicationDetail>, IApplicationDetailRepository
    {
        public ApplicationDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        //public string GetAppNumber()
        //{
        //    return (DateTime.Now.ToString("yy") + Convert.ToString((_context.ApplicationDetail.Max(c => c.Id) + 1)));
        //}
    }
}
