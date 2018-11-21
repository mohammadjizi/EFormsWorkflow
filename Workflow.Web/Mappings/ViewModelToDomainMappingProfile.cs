using AutoMapper;
using Workflow.Models;
using Workflow.Web.ViewModels;

namespace Workflow.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<EquationCustomer, ApplicationCustomer>().ForMember(c => c.Id, x => x.Ignore());
            CreateMap<AccountMaintenanceViewModel, Account>()
                .ForSourceMember(c => c.DateCreated, x => x.Ignore())
                .ForSourceMember(c => c.RequestedBy, x => x.Ignore())
                .ForSourceMember(c => c.AppType, x => x.Ignore())
                .ForSourceMember(c => c.CustomerAccount, x => x.Ignore());

        }
    }
}

