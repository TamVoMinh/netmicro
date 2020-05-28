using AutoMapper;
namespace Nmro.IAM.Application.UseCases.PersistedGrants.Models.Mappers
{
    public static class PersistedGrantMappers
    {
        static PersistedGrantMappers()
        {
            Mapper = new MapperConfiguration(cfg =>cfg.AddProfile<PersistedGrantMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        public static Models.PersistedGrant ToModel(this Domain.Entities.PersistedGrant entity)
        {
            return entity == null ? null : Mapper.Map<Models.PersistedGrant>(entity);
        }
        public static Domain.Entities.PersistedGrant ToEntity(this Models.PersistedGrant model)
        {
            return model == null ? null : Mapper.Map<Domain.Entities.PersistedGrant>(model);
        }
        public static void UpdateEntity(this Models.PersistedGrant model, Domain.Entities.PersistedGrant entity)
        {
            Mapper.Map(model, entity);
        }
    }
}
