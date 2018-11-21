using AutoMapper;
using Workflow.Models;

namespace Workflow.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<EquationCustomer, ApplicationCustomer>().ForMember(c => c.Id, x => x.Ignore());
            //CreateMap<AccountMaintenanceViewModel, Account>()
            //    .ForSourceMember(c=>c.DateCreated,x=>x.Ignore())
            //    .ForSourceMember(c=>c.RequestedBy,x=>x.Ignore())
            //    .ForSourceMember(c=>c.AppType,x=>x.Ignore())
            //    .ForSourceMember(c=>c.CustomerAccount,x=>x.Ignore());

        }
    }
}
