using WorkflowForms.Core.Models;

namespace WorkflowForms.Core.Repositories
{
    public interface IApplicationDescriptionRepository
    {
        ApplicationDescription GetAppDescription(string appCode);
    }
}
