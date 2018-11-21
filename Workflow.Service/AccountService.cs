using Workflow.Data.Infrastructure;
using Workflow.Forms.Repositories;

namespace Workflow.Service
{
    public class AccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IUnitOfWork unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
        }
    }
}
