namespace Workflow.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
