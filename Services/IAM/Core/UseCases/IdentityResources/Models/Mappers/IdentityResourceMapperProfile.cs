using System.Collections.Generic;
using AutoMapper;
namespace Nmro.IAM.Core.UseCases.IdentityResources.Dtos.Mappers
{
    /// <summary>
    /// Defines entity/model mapping for identity resources.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class IdentityResourceMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="IdentityResourceMapperProfile"/>
        /// </summary>
        public IdentityResourceMapperProfile()
        {
            CreateMap<Core.Entities.IdentityResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();
            CreateMap<Core.Entities.IdentityResource, Dtos.IdentityResource>(MemberList.Destination)
                .ConstructUsing(src => new Dtos.IdentityResource())
                .ReverseMap();
            CreateMap<Core.Entities.IdentityResourceClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}
