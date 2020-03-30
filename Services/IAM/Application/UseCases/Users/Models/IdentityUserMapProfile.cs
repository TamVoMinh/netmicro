using AutoMapper;
namespace Nmro.IAM.Application.UseCases.Users.Models
{
    public class IdentityUserMapProfile : Profile
    {
        public IdentityUserMapProfile()
        {
            CreateMap<Domain.Entities.IdentityUser, IdentityUser>();
        }
    }
}
