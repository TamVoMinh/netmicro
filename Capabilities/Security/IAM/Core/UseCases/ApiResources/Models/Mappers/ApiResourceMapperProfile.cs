using System.Collections.Generic;
using AutoMapper;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos.Mappers
{
    /// <summary>
    /// Defines entity/model mapping for API resources.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ApiResourceMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="ApiResourceMapperProfile"/>
        /// </summary>
        public ApiResourceMapperProfile()
        {
            CreateMap<Core.Entities.ApiResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();
            CreateMap<Core.Entities.ApiResource, Dtos.ApiResource>(MemberList.Destination)
                .ConstructUsing(src => new Dtos.ApiResource())
                .ForMember(x => x.ApiSecrets, opts => opts.MapFrom(x => x.Secrets))
                .ForMember(x=>x.AllowedAccessTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x=>x.AllowedAccessTokenSigningAlgorithms))
                .ReverseMap()
                .ForMember(x=>x.AllowedAccessTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x=>x.AllowedAccessTokenSigningAlgorithms));
            CreateMap<Core.Entities.ApiResourceClaim, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
            CreateMap<Core.Entities.ApiResourceSecret, Core.Dtos.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();
            CreateMap<Core.Entities.ApiResourceScope, string>()
                .ConstructUsing(x => x.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));
        }
    }
}
