using System.Collections.Generic;
using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos.Mappers
{
    /// <summary>
    /// Defines entity/model mapping for scopes.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ScopeMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="ScopeMapperProfile"/>
        /// </summary>
        public ScopeMapperProfile()
        {
            CreateMap<Core.Entities.ApiScopeProperty, KeyValuePair<string, string>>()
                .ReverseMap();
            CreateMap<Core.Entities.ApiScopeClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
            CreateMap<Core.Entities.ApiScope, Dtos.ApiScope>(MemberList.Destination)
                .ConstructUsing(src => new Dtos.ApiScope())
                .ForMember(x => x.Properties, opts => opts.MapFrom(x => x.Properties))
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(x => x.UserClaims))
                .ReverseMap();
        }
    }
}
