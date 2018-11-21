using System.Threading.Tasks;
using Workflow.Data.Infrastructure;
using Workflow.Data.Repositories;
using Workflow.Models;

namespace Workflow.Service
{
    public class EquationCustomerService : IEquationCustomerService
    {
        private readonly IEquationCustomerRepository _equationCustomerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EquationCustomerService(IEquationCustomerRepository equationCustomerRepository, IUnitOfWork unitOfWork)
        {
            _equationCustomerRepository = equationCustomerRepository;
            _unitOfWork = unitOfWork;
        }

        async Task<EquationCustomer> IEquationCustomerService.SearchCustomer(string accountNumber)
        {
            return await _equationCustomerRepository.Get(c => c.AccountNumber == accountNumber);
        }
    }
}
