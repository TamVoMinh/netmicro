using AutoMapper;
namespace Nmro.IAM.Application.Clients.Mappers
{
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
                .CreateMapper();
        }
        internal static IMapper Mapper { get; }
        public static Models.Client ToModel(this Domain.Entities.Client entity)
        {
            return Mapper.Map<Models.Client>(entity);
        }
        public static Domain.Entities.Client ToEntity(this Models.Client model)
        {
            return Mapper.Map<Domain.Entities.Client>(model);
        }

        public static Domain.Entities.Client ToEntity(this Models.CreateClientModel model)
        {
            return Mapper.Map<Domain.Entities.Client>(model);
        }

        public static Domain.Entities.Client ToUpdateEntity(this Models.UpdateClientModel model, Domain.Entities.Client client)
        {
            return Mapper.Map<Models.UpdateClientModel, Domain.Entities.Client>(model, client);
        }
    }
}
