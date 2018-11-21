using Workflow.Data.Infrastructure;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class EquationCustomerRepository : RepositoryBase<EquationCustomer>, IEquationCustomerRepository
    {
        public EquationCustomerRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        //public async Task<EquationCustomer> SearchCustomer(string accountNumber)
        //{
        //    return await _context.EquationCustomer.FirstOrDefaultAsync(m => m.AccountNumber == accountNumber);

        //}

    }
}
