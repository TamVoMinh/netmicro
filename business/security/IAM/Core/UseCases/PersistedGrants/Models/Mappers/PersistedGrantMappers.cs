using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Dtos.Mappers
{
    public static class PersistedGrantMappers
    {
        static PersistedGrantMappers()
        {
            Mapper = new MapperConfiguration(cfg =>cfg.AddProfile<PersistedGrantMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        public static Dtos.PersistedGrant ToModel(this Core.Entities.PersistedGrant entity)
        {
            return entity == null ? null : Mapper.Map<Dtos.PersistedGrant>(entity);
        }
        public static Core.Entities.PersistedGrant ToEntity(this Dtos.PersistedGrant model)
        {
            return model == null ? null : Mapper.Map<Core.Entities.PersistedGrant>(model);
        }
        public static void UpdateEntity(this Dtos.PersistedGrant model, Core.Entities.PersistedGrant entity)
        {
            Mapper.Map(model, entity);
        }
    }
}
