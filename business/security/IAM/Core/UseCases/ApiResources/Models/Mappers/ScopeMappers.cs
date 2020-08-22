using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for scopes.
    /// </summary>
    public static class ScopeMappers
    {
        static ScopeMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ScopeMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Dtos.ApiScope ToModel(this Core.Entities.ApiScope entity)
        {
            return entity == null ? null : Mapper.Map<Dtos.ApiScope>(entity);
        }
        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Core.Entities.ApiScope ToEntity(this Dtos.ApiScope model)
        {
            return model == null ? null : Mapper.Map<Core.Entities.ApiScope>(model);
        }
    }
}
