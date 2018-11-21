using Workflow.Data.Infrastructure;
using Workflow.Forms.Repositories;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        //public void CreateAccount(Account account)
        //{
        //    _context.Add(account);
        //}

        //public int GetAppNumber()
        //{
        //    return _context.Account.Max(c => c.Id);
        //}
    }
}
