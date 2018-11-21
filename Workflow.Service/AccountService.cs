using Workflow.Data.Infrastructure;
using Workflow.Forms.Repositories;
using Workflow.Models;

namespace Workflow.Service
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateAccount(Account account)
        {
            _accountRepository.Add(account);
        }

        public int GetAppNumber()
        {
           return _accountRepository.Max(c => c.Id);
        }
    }
}
