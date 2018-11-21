using Workflow.Data.Infrastructure;
using Workflow.Data.Repositories;

namespace Workflow.Service
{
    public class EquationCustomerService
    {
        private readonly IEquationCustomerRepository equationCustomerRepository;
        private readonly IUnitOfWork unitOfWork;

        public EquationCustomerService(IEquationCustomerRepository equationCustomerRepository, IUnitOfWork unitOfWork)
        {
            this.equationCustomerRepository = equationCustomerRepository;
            this.unitOfWork = unitOfWork;
        }
    }
}
