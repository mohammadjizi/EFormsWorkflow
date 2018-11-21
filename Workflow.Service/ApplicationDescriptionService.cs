using System.Threading.Tasks;
using Workflow.Data.Infrastructure;
using Workflow.Data.Repositories;
using Workflow.Models;

namespace Workflow.Service
{
    public class ApplicationDescriptionService : IApplicationDescriptionService
    {
        private readonly IApplicationDescriptionRepository _applicationDescriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationDescriptionService(IApplicationDescriptionRepository applicationDescriptionRepository,
            IUnitOfWork unitOfWork)
        {
            _applicationDescriptionRepository = applicationDescriptionRepository;
            _unitOfWork = unitOfWork;
        }

        async Task<ApplicationDescription> IApplicationDescriptionService.GetAppDescription(string appCode)
        {
            return await _applicationDescriptionRepository.Get(a => a.AppCode == appCode);
        }
    }

}
