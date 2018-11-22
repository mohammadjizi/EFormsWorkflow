using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Workflow.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private WorkflowEntities dbContext;
        private IConfiguration _configuration;

        public UnitOfWork(IDbFactory dbFactory, IConfiguration configuration)
        {
            _dbFactory = dbFactory;
            _configuration = configuration;
        }

        public WorkflowEntities DbContext
        {
            get { return dbContext ?? (dbContext = _dbFactory.Init(_configuration)); }
        }

        public Task<int> Commit()
        {
         return DbContext.Commit();
        }

        
    }
}
