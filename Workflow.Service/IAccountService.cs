using Workflow.Models;

namespace Workflow.Service
{
    public interface IAccountService
    {
        void CreateAccount(Account account);

        int GetAppNumber();
    }
}
