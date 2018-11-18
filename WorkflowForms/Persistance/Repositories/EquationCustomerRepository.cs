using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorkflowForms.Core.Models;
using WorkflowForms.Core.Repositories;
using WorkflowForms.Data;

namespace WorkflowForms.Persistance.Repositories
{
    public class EquationCustomerRepository : IEquationCustomerRepository
    {
        private ApplicationDbContext _context { get; }

        public EquationCustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EquationCustomer> SearchCustomer(string accountNumber)
        {
            return await _context.EquationCustomer.FirstOrDefaultAsync(m => m.AccountNumber == accountNumber);

        }

    }
}
