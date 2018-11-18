using System.Threading.Tasks;
using WorkflowForms.Core.Models;

namespace WorkflowForms.Core.Repositories
{
    public interface IEquationCustomerRepository
    {
        Task<EquationCustomer> SearchCustomer(string accountNumber);

    }
}
