using Workflow.Data.Infrastructure;
using Workflow.Data.Repositories;

namespace Workflow.Service
{
    public class ApplicationDetailService
    {
        private readonly IApplicationDetailRepository applicationDetailRepository;
        private readonly IUnitOfWork unitOfWork;

        public ApplicationDetailService(IApplicationDetailRepository applicationDetailRepository, IUnitOfWork unitOfWork)
        {
            this.applicationDetailRepository = applicationDetailRepository;
            this.unitOfWork = unitOfWork;
        }
    }
}
