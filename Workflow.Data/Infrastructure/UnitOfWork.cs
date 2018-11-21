using System.Threading.Tasks;

namespace Workflow.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private WorkflowEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public WorkflowEntities DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public Task<int> Commit()
        {
         return dbContext.Commit();
        }

        
    }
}
