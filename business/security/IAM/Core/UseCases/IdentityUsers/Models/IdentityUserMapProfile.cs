using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.Users.Dtos
{
    public class IdentityUserMapProfile : Profile
    {
        public IdentityUserMapProfile()
        {
            CreateMap<Core.Entities.IdentityUser, IdentityUser>();
        }
    }
}
