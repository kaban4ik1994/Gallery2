using AutoMapper;
using Gallery.Models.Models;
using Gallety.Entities;

namespace Gallery.Mappings.Mappings
{
    public class TokenMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbTokenToToken();
            MapTokenToDbToken();
          //  Mapper.AssertConfigurationIsValid();
        }

        private void MapDbTokenToToken()
        {
            CreateMap<DbToken, Token>()
                .ForMember(de => de.TokenId, options => options.MapFrom(so => so.TokenId))
                .ForMember(de => de.TokenContent, options => options.MapFrom(so => so.Token))
                .ForMember(de => de.UserId, options => options.MapFrom(so => so.UserId))
                .ForMember(de => de.User, options => options.MapFrom(so => so.User));
        }

        private void MapTokenToDbToken()
        {
            CreateMap<Token, DbToken>()
               .ForMember(de => de.TokenId, options => options.MapFrom(so => so.TokenId))
               .ForMember(de => de.Token, options => options.MapFrom(so => so.TokenContent))
               .ForMember(de => de.UserId, options => options.MapFrom(so => so.UserId))
               .ForMember(de => de.User, options => options.MapFrom(so => so.User));
        }
    }
}
