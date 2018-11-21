using Workflow.Data.Infrastructure;
using Workflow.Data.Repositories;

namespace Workflow.Service
{
    public  class ApplicationDescriptionService
    {
        private readonly IApplicationDescriptionRepository applicationDescriptionRepository;
        private readonly IUnitOfWork unitOfWork;

        public ApplicationDescriptionService(IApplicationDescriptionRepository applicationDescriptionRepository, IUnitOfWork unitOfWork)
        {
            this.applicationDescriptionRepository = applicationDescriptionRepository;
            this.unitOfWork = unitOfWork;
        }
    }

}
