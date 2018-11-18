using System.Linq;
using WorkflowForms.Core.Models;
using WorkflowForms.Core.Repositories;
using WorkflowForms.Data;

namespace WorkflowForms.Persistance.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public ApplicationDbContext _context { get; set; }
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAccount(Account account)
        {
            _context.Add(account);
        }

        public int GetAppNumber()
        {
           return _context.Account.Max(c => c.Id);
        }
    }
}
