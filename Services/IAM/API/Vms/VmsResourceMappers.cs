using AutoMapper;

namespace Nmro.IAM.API.Vms
{
    public static class VmsResourceMappers
    {
        static VmsResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<VmsMapProfile>()).CreateMapper();
        }
        internal static IMapper Mapper { get; }

        public static IdentityResource ToViewModel(this Application.UseCases.Resources.Models.IdentityResource model)
        {
            return model == null ? null : Mapper.Map<IdentityResource>(model);
        }

        public static ApiResource ToViewModel(this Application.UseCases.Resources.Models.ApiResource model)
        {
            return model == null ? null : Mapper.Map<ApiResource>(model);
        }
    }
}
