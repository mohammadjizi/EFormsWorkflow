using Microsoft.Extensions.Configuration;

namespace Workflow.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        WorkflowEntities dbContext;

        public WorkflowEntities Init(IConfiguration configuration)
        {
            return dbContext ?? (dbContext = new WorkflowEntities(configuration));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
