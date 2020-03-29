using AutoMapper;
using System.Linq;

namespace Nmro.IAM.API.Vms
{
    public class VmsMapProfile : Profile
    {
        public VmsMapProfile()
        {
            CreateMap<Application.Models.Secret, Secret>();
            CreateMap<Application.UseCases.Resources.Models.ApiScope, Scope>();
            CreateMap<Application.UseCases.Resources.Models.IdentityResource, IdentityResource>();
            CreateMap<Application.UseCases.Resources.Models.ApiResource, ApiResource>()
                .ForMember(x=>x.Scopes, opts => opts.MapFrom(x => x.Scopes.Select(s => new Scope{Name = s})));
        }
    }
}
