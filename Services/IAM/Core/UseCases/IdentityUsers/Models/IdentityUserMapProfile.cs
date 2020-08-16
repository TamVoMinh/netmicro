using AutoMapper;
namespace Nmro.IAM.Core.UseCases.Users.Dtos
{
    public class IdentityUserMapProfile : Profile
    {
        public IdentityUserMapProfile()
        {
            CreateMap<Core.Entities.IdentityUser, IdentityUser>();
        }
    }
}
