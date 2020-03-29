using AutoMapper;
namespace Nmro.IAM.Application.Users.Models
{
    public class IdentityUserMapProfile : Profile
    {
        public IdentityUserMapProfile()
        {
            CreateMap<Domain.Entities.IdentityUser, IdentityUserModel>();
        }
    }
}
