using AutoMapper;
using Gallery.Models.Models;
using Gallery.WebUI.Models.Picture;

namespace Gallery.WebUI.Mappings
{
    public class PictureMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapPictureToPictureViewModel();
            MapPictureViewModelToPicture();
        }

        private void MapPictureViewModelToPicture()
        {
            CreateMap<PictureViewModel, Picture>()
                .ForMember(de => de.PictureId, options => options.MapFrom(so => so.Id))
                .ForMember(de => de.PictureName, options => options.MapFrom(so => so.Name))
                .ForMember(de => de.Painter, options => options.Ignore())
                .ForMember(de => de.Genre, options => options.Ignore())
                .ForMember(de => de.Departament, options => options.Ignore())
                .ForMember(de => de.Images, options => options.MapFrom(so => so.Images))
                .ForMember(de => de.PictureDepartamentId, options => options.MapFrom(so => so.DepartamentId))
                .ForMember(de => de.PicturePainterId, options => options.MapFrom(so => so.PainterId))
                .ForMember(de => de.PictureGenreId, options => options.MapFrom(so => so.GenreId))
                .ForMember(de => de.Comments, options => options.Ignore());
        }

        private void MapPictureToPictureViewModel()
        {
            CreateMap<Picture, PictureViewModel>()
                .ForMember(de => de.Id, options => options.MapFrom(so => so.PictureId))
                .ForMember(de => de.Name, options => options.MapFrom(so => so.PictureName))
                .ForMember(de => de.DepartamentId, options => options.MapFrom(so => so.PictureDepartamentId))
                .ForMember(de => de.GenreId, options => options.MapFrom(so => so.PictureGenreId))
                .ForMember(de => de.PainterId, options => options.MapFrom(so => so.PicturePainterId))
                .ForMember(de => de.Images, options => options.MapFrom(so => so.Images))
                .ForMember(de => de.GenreSelectionList, options => options.Ignore())
                .ForMember(de => de.DepartamentSelectionList, options => options.Ignore())
                .ForMember(de => de.PainterSelectionList, options => options.Ignore());
        }
    }
}