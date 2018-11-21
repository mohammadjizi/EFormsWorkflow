using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Service
{
    public interface IApplicationDescriptionService
    {
        Task< ApplicationDescription> GetAppDescription(string appCode);
    }
}
