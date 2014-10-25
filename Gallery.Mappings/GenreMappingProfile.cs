using AutoMapper;
using Gallery.ModelsAPI;
using Gallety.Entities;

namespace Gallery.Mappings
{
    public class GenreMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbGenreToGenre();
            MapGenreToDbGenre();
            Mapper.AssertConfigurationIsValid();
        }

        private void MapDbGenreToGenre()
        {
            CreateMap<DbGenre, Genre>()
                .ForMember(de => de.GenreId, options => options.MapFrom(so => so.GenreId))
                .ForMember(de => de.GenreName, options => options.MapFrom(so => so.GenreName))
                .ForMember(de => de.Pictures, options => options.MapFrom(so => so.Pictures));
        }

        private void MapGenreToDbGenre()
        {
            CreateMap<Genre, DbGenre>()
                .ForMember(de => de.GenreId, options => options.MapFrom(so => so.GenreId))
                .ForMember(de => de.GenreName, options => options.MapFrom(so => so.GenreName))
                .ForMember(de => de.Pictures, options => options.MapFrom(so => so.Pictures));
        }
    }
}
