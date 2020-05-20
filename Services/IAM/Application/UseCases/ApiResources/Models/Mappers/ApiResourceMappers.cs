using AutoMapper;
namespace Nmro.IAM.Application.UseCases.ApiResources.Models.Mappers
{
    public static class ApiResourceMappers
    {
        static ApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        public static Models.ApiResource ToModel(this Domain.Entities.ApiResource entity)
        {
            return entity == null ? null : Mapper.Map<Models.ApiResource>(entity);
        }
        public static Domain.Entities.ApiResource ToEntity(this Models.ApiResource model)
        {
            return model == null ? null : Mapper.Map<Domain.Entities.ApiResource>(model);
        }
    }
}
