using AutoMapper;
using Gallery.Models.Models;
using Gallery.WebUI.Models.Genre;

namespace Gallery.WebUI.Mappings
{
    public class GenreMappingProfile: Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapGenreToGenreViewModel();
            MapGenreViewModelToGenre();
        }

        private void MapGenreViewModelToGenre()
        {
            CreateMap<GenreViewModel, Genre>()
                .ForMember(de => de.GenreId, options => options.MapFrom(so => so.Id))
                .ForMember(de => de.GenreName, options => options.MapFrom(so => so.Name))
                .ForMember(de => de.Pictures, options => options.Ignore());

        }

        private void MapGenreToGenreViewModel()
        {
            CreateMap<Genre, GenreViewModel>()
                .ForMember(de => de.Id, options => options.MapFrom(so => so.GenreId))
                .ForMember(de => de.Name, options => options.MapFrom(so => so.GenreName));
        }
    }
}