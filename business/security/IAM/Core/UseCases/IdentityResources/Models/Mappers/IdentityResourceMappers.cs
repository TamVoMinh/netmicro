using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for identity resources.
    /// </summary>
    public static class IdentityResourceMappers
    {
        static IdentityResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Dtos.IdentityResource ToModel(this Core.Entities.IdentityResource entity)
        {
            return entity == null ? null : Mapper.Map<Dtos.IdentityResource>(entity);
        }
        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Core.Entities.IdentityResource ToEntity(this Dtos.IdentityResource model)
        {
            return model == null ? null : Mapper.Map<Core.Entities.IdentityResource>(model);
        }
    }
}
