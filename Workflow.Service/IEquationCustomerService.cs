using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Service
{
    public interface IEquationCustomerService
    {
       Task< EquationCustomer> SearchCustomer(string accountNumber);
    }
}
