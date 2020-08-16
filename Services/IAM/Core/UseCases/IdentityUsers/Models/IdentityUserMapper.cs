using AutoMapper;
namespace Nmro.IAM.Core.UseCases.Users.Dtos
{
    public static class IdentityUserMapper
    {
        static IdentityUserMapper()
        {
             Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityUserMapProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }

        public static IdentityUser ToModel(this Core.Entities.IdentityUser entity)
        {
            return Mapper.Map<IdentityUser>(entity);
        }

    }
}
