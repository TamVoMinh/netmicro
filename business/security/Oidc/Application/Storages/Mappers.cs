using AutoMapper;
using Nmro.Oidc.Infrastructure.IamClient.Models;

namespace Nmro.Oidc.Application.Storages
{
    public static class ModelsMappers
    {
        static ModelsMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapProfile>()).CreateMapper();
        }
        internal static IMapper Mapper { get; }

        public static IdentityServer4.Models.IdentityResource ToIds4Model(this IdentityResource model)
        {
            return model == null ? null : Mapper.Map<IdentityServer4.Models.IdentityResource>(model);
        }

        public static IdentityServer4.Models.ApiResource ToIds4Model(this ApiResource model)
        {
            return model == null ? null : Mapper.Map<IdentityServer4.Models.ApiResource>(model);
        }

        public static IdentityServer4.Models.Client ToIds4Model(this Client model)
        {
            return model == null ? null : Mapper.Map<IdentityServer4.Models.Client>(model);
        }

        public static Oidc.Models.User ToViewModel(this IdentityUser model)
        {
            return model == null ? null : Mapper.Map<Oidc.Models.User>(model);
        }

        public static IdentityServer4.Models.Resources ToIds4Model(this AllResources model)
        {
            return model == null ? null : Mapper.Map<IdentityServer4.Models.Resources>(model);
        }

        public static IdentityServer4.Models.PersistedGrant ToIds4Model(this PersistedGrant model)
        {
            return model == null ? null : Mapper.Map<IdentityServer4.Models.PersistedGrant>(model);
        }

        public static PersistedGrant ToModel(this IdentityServer4.Models.PersistedGrant model)
        {
            return model == null ? null : Mapper.Map<PersistedGrant>(model);
        }
    }
}
