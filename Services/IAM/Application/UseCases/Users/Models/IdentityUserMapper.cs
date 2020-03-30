using AutoMapper;
namespace Nmro.IAM.Application.UseCases.Users.Models
{
    public static class IdentityUserMapper
    {
        static IdentityUserMapper()
        {
             Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityUserMapProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }

        public static IdentityUser ToModel(this Domain.Entities.IdentityUser entity)
        {
            return Mapper.Map<IdentityUser>(entity);
        }

    }
}
