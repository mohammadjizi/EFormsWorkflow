using Microsoft.Extensions.Configuration;
using Workflow.Data.Infrastructure;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class ApplicationDescriptionRepository :  RepositoryBase<ApplicationDescription>, IApplicationDescriptionRepository
    {
        public ApplicationDescriptionRepository(IDbFactory dbFactory, IConfiguration configuration)
            : base(dbFactory, configuration) { }
    }
}
