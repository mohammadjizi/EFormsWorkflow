using System.Threading.Tasks;

namespace Workflow.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}
