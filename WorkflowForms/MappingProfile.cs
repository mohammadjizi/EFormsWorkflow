using AutoMapper;
using WorkflowForms.Core.Models;
using WorkflowForms.Core.ViewModels;

namespace WorkflowForms
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EquationCustomer, ApplicationCustomer>().ForMember(c => c.Id, x => x.Ignore());
            CreateMap<AccountMaintenanceViewModel, Account>()
                .ForSourceMember(c=>c.DateCreated,x=>x.Ignore())
                .ForSourceMember(c=>c.RequestedBy,x=>x.Ignore())
                .ForSourceMember(c=>c.AppType,x=>x.Ignore())
                .ForSourceMember(c=>c.CustomerAccount,x=>x.Ignore());

        }
    }
}
