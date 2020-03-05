using AutoMapper;
using Nmro.IAM.Models;
using Nmro.IAM.Repository.Entities;

namespace Nmro.IAM
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<IdentityUser, IdentityUserModel>().ReverseMap();
            CreateMap<IdentityUser, UserProfileModel>().ReverseMap();
            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<Secret, SecretModel>().ReverseMap();
            CreateMap<ApiResource, ApiResourceModel>().ReverseMap();
            CreateMap<Scope, ScopeModel>().ReverseMap();
            CreateMap<IdentityResource, IdentityResourceModel>().ReverseMap();
        }
    }
}

