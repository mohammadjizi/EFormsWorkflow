using Workflow.Data.Infrastructure;
using Workflow.Forms.Repositories;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
