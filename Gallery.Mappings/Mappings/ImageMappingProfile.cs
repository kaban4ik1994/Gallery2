﻿using System.Linq;
using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;

namespace Gallery.Mappings.Mappings
{
    public class ImageMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbImageToImage();
            MapImageToDbImage();
            //  Mapper.AssertConfigurationIsValid();
        }

        private void MapDbImageToImage()
        {
            CreateMap<DbImage, Image>()
                .ForMember(de => de.ImageId, options => options.MapFrom(so => so.ImageId))
                .ForMember(de => de.ImageName, options => options.MapFrom(so => so.ImageName))
                .ForMember(de => de.ImageData, options => options.MapFrom(so => so.ImageData))
                .ForMember(de => de.ImageHeight, options => options.MapFrom(so => so.ImageHeight))
                .ForMember(de => de.ImageWidth, options => options.MapFrom(so => so.ImageWidth))
                .ForMember(de => de.ImagePainterId, options => options.MapFrom(so => so.ImagePainterId))
                .ForMember(de => de.ImagePictureId, options => options.MapFrom(so => so.ImagePictureId))
                .ForMember(de => de.ImageUserId, options => options.MapFrom(so => so.ImageUserId))
                .ForMember(de => de.Painter, options => options.MapFrom(so => so.Painter))
                .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture))
                .ForMember(de => de.User, options => options.MapFrom(so => so.DbUser))
                .ForMember(de => de.ImageExtension, options => options.MapFrom(so => so.ImageExtension));

        }

        private void MapImageToDbImage()
        {
            CreateMap<Image, DbImage>()
                .ForMember(de => de.ImageId, options => options.MapFrom(so => so.ImageId))
                .ForMember(de => de.ImageName, options => options.MapFrom(so => so.ImageName))
                .ForMember(de => de.ImageData, options => options.MapFrom(so => so.ImageData))
                .ForMember(de => de.ImageHeight, options => options.MapFrom(so => so.ImageHeight))
                .ForMember(de => de.ImageWidth, options => options.MapFrom(so => so.ImageWidth))
                .ForMember(de => de.ImagePainterId, options => options.MapFrom(so => so.ImagePainterId))
                .ForMember(de => de.ImagePictureId, options => options.MapFrom(so => so.ImagePictureId))
                .ForMember(de => de.ImageUserId, options => options.MapFrom(so => so.ImageUserId))
                .ForMember(de => de.Painter, options => options.MapFrom(so => so.Painter))
                .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture))
                .ForMember(de => de.DbUser, options => options.MapFrom(so => so.User))
                .ForMember(de => de.ImageExtension, options => options.MapFrom(so => so.ImageExtension));
        }
    }
}
