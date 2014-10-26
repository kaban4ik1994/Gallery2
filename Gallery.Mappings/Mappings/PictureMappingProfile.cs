using AutoMapper;
using Gallery.Models.Models;
using Gallety.Entities;

namespace Gallery.Mappings.Mappings
{
    public class PictureMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbPictureToPicture();
            MapPictureToDbPicture();
          //  Mapper.AssertConfigurationIsValid();
        }

        private void MapDbPictureToPicture()
        {
            CreateMap<DbPicture, Picture>()
                .ForMember(de => de.PictureId, options => options.MapFrom(so => so.PictureId))
                .ForMember(de => de.PictureName, options => options.MapFrom(so => so.PictureName))
                .ForMember(de => de.PictureDepartamentId, options => options.MapFrom(so => so.PictureDepartamentId))
                .ForMember(de => de.PicturePainterId, options => options.MapFrom(so => so.PicturePainterId))
                .ForMember(de => de.PictureGenreId, options => options.MapFrom(so => so.PictureGenreId))
                .ForMember(de => de.Departament, options => options.MapFrom(so => so.DbDepartament))
                .ForMember(de => de.Painter, options => options.MapFrom(so => so.Painter))
                .ForMember(de => de.Genre, options => options.MapFrom(so => so.Genre))
                .ForMember(de => de.Comments, options => options.MapFrom(so => so.Comments))
                .ForMember(de => de.Images, options => options.MapFrom(so => so.Images));
        }

        private void MapPictureToDbPicture()
        {
            CreateMap<Picture, DbPicture>()
               .ForMember(de => de.PictureId, options => options.MapFrom(so => so.PictureId))
               .ForMember(de => de.PictureName, options => options.MapFrom(so => so.PictureName))
               .ForMember(de => de.PictureDepartamentId, options => options.MapFrom(so => so.PictureDepartamentId))
               .ForMember(de => de.PicturePainterId, options => options.MapFrom(so => so.PicturePainterId))
               .ForMember(de => de.PictureGenreId, options => options.MapFrom(so => so.PictureGenreId))
               .ForMember(de => de.DbDepartament, options => options.MapFrom(so => so.Departament))
               .ForMember(de => de.Painter, options => options.MapFrom(so => so.Painter))
               .ForMember(de => de.Genre, options => options.MapFrom(so => so.Genre))
               .ForMember(de => de.Comments, options => options.MapFrom(so => so.Comments))
               .ForMember(de => de.Images, options => options.MapFrom(so => so.Images));
        }
    }
}
