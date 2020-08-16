using AutoMapper;
namespace Nmro.IAM.Core.UseCases.Users.Models
{
    public class IdentityUserMapProfile : Profile
    {
        public IdentityUserMapProfile()
        {
            CreateMap<Domain.Entities.IdentityUser, IdentityUser>();
        }
    }
}
