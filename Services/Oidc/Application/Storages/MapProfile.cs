using AutoMapper;
using Nmro.Oidc.Infrastructure.IamClient.Models;
using System.Linq;

namespace Nmro.Oidc.Application.Storages
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Secret, IdentityServer4.Models.Secret>();
            CreateMap<ApiScope, IdentityServer4.Models.Scope>();
            CreateMap<IdentityResource, IdentityServer4.Models.IdentityResource>();
            CreateMap<ApiResource, IdentityServer4.Models.ApiResource>()
                .ForMember(x=>x.Scopes, opts => opts.MapFrom(x => x.Scopes.Select(s => new IdentityServer4.Models.Scope{Name = s})));
            CreateMap<Client, IdentityServer4.Models.Client>();
            CreateMap<AllResources, IdentityServer4.Models.Resources>()
                .ForMember(des => des.ApiResources, opt => opt.MapFrom(p=>p.ApiResources))
                .ForMember(des => des.IdentityResources, opt => opt.MapFrom(p=>p.IdentityResources));

            CreateMap<IdentityUser, Oidc.Models.User>();
        }
    }
}
