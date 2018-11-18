using System.Threading.Tasks;
using WorkflowForms.Core.Repositories;

namespace WorkflowForms.Core
{
    public interface IUnitOfWork
    {
        IEquationCustomerRepository Customers { get; set; }
        IApplicationDescriptionRepository AppsDescription { get; set; }
        IAccountRepository Accounts { get; set; }
        IApplicationDetailRepository AppsDetail { get; set; }

        Task<int> Complete();
    }
}
