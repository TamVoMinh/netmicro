using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos.Mappers
{
    public static class ApiResourceMappers
    {
        static ApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        public static Dtos.ApiResource ToModel(this Core.Entities.ApiResource entity)
        {
            return entity == null ? null : Mapper.Map<Dtos.ApiResource>(entity);
        }
        public static Core.Entities.ApiResource ToEntity(this Dtos.ApiResource model)
        {
            return model == null ? null : Mapper.Map<Core.Entities.ApiResource>(model);
        }
    }
}
