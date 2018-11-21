namespace Workflow.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        WorkflowEntities dbContext;

        public WorkflowEntities Init()
        {
            return dbContext ?? (dbContext = new WorkflowEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
