using System;
using Workflow.Data.Infrastructure;
using Workflow.Data.Repositories;

namespace Workflow.Service
{
    public class ApplicationDetailService:IApplicationDetailService
    {
        private readonly IApplicationDetailRepository _applicationDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationDetailService(IApplicationDetailRepository applicationDetailRepository, IUnitOfWork unitOfWork)
        {
            _applicationDetailRepository = applicationDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public string GetAppNumber()
        {
            return (DateTime.Now.ToString("yy") + Convert.ToString((_applicationDetailRepository.Max(c => c.Id) + 1)));
        }
    }
}
