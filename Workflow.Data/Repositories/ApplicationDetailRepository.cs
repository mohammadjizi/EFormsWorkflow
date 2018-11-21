using Workflow.Data.Infrastructure;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class ApplicationDetailRepository : RepositoryBase<ApplicationDetail>, IApplicationDetailRepository
    {
        public ApplicationDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
