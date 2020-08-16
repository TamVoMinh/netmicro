using AutoMapper;
namespace Nmro.IAM.Core.UseCases.PersistedGrants.Models.Mappers
{
    public class PersistedGrantMapperProfile:Profile
    {
        public PersistedGrantMapperProfile()
        {
            CreateMap<Domain.Entities.PersistedGrant, Models.PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
