using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Dtos.Mappers
{
    public class PersistedGrantMapperProfile:Profile
    {
        public PersistedGrantMapperProfile()
        {
            CreateMap<Core.Entities.PersistedGrant, Dtos.PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
