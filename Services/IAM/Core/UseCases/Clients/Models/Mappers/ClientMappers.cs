using AutoMapper;
namespace Nmro.IAM.Core.UseCases.Clients.Dtos.Mappers
{
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        public static Dtos.Client ToModel(this Core.Entities.Client entity)
        {
            return Mapper.Map<Dtos.Client>(entity);
        }
        public static Core.Entities.Client ToEntity(this Dtos.Client model)
        {
            return Mapper.Map<Core.Entities.Client>(model);
        }

        public static Core.Entities.Client ToEntity(this Dtos.CreateClientModel model)
        {
            return Mapper.Map<Core.Entities.Client>(model);
        }

        public static Core.Entities.Client ToUpdateEntity(this Dtos.UpdateClientModel model, Core.Entities.Client client)
        {
            return Mapper.Map<Dtos.UpdateClientModel, Core.Entities.Client>(model, client);
        }
    }
}
