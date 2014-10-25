﻿using AutoMapper;
using Gallery.ModelsAPI;
using Gallety.Entities;

namespace Gallery.Mappings
{
    public class PainterMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbPainterToPainter();
            MapPainterToDbPainter();
            Mapper.AssertConfigurationIsValid();
        }

        private void MapDbPainterToPainter()
        {
            CreateMap<DbPainter, Painter>()
                .ForMember(de => de.PainterId, options => options.MapFrom(so => so.PainterId))
                .ForMember(de => de.PainterFullName, options => options.MapFrom(so => so.PainterFullName))
                .ForMember(de => de.Pictures, options => options.MapFrom(so => so.Pictures))
                .ForMember(de => de.Images, options => options.MapFrom(so => so.Images));
        }

        private void MapPainterToDbPainter()
        {
            CreateMap<Painter, DbPainter>()
                .ForMember(de => de.PainterId, options => options.MapFrom(so => so.PainterId))
                .ForMember(de => de.PainterFullName, options => options.MapFrom(so => so.PainterFullName))
                .ForMember(de => de.Pictures, options => options.MapFrom(so => so.Pictures))
                .ForMember(de => de.Images, options => options.MapFrom(so => so.Images));
        }
    }
}