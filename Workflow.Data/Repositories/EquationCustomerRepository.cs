using Microsoft.Extensions.Configuration;
using Workflow.Data.Infrastructure;
using Workflow.Models;

namespace Workflow.Data.Repositories
{
    public class EquationCustomerRepository : RepositoryBase<EquationCustomer>, IEquationCustomerRepository
    {
        public EquationCustomerRepository(IDbFactory dbFactory, IConfiguration configuration)
            : base(dbFactory,configuration) { }
    }
}
