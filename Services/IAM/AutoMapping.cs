using AutoMapper;
using Nmro.IAM.Models;
using Nmro.IAM.Reposistory.Entities;

namespace Nmro.IAM
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<IdentityUser, IdentityUserModel>().ReverseMap();
        }
    }
}

