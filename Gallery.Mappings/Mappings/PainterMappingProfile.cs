﻿using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;

namespace Gallery.Mappings.Mappings
{
    public class PainterMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbPainterToPainter();
            MapPainterToDbPainter();
          //  Mapper.AssertConfigurationIsValid();
        }

        private void MapDbPainterToPainter()
        {
            CreateMap<DbPainter, Painter>()
                .ForMember(de => de.PainterId, options => options.MapFrom(so => so.PainterId))
                .ForMember(de => de.PainterFullName, options => options.MapFrom(so => so.PainterFullName))
                .ForMember(de => de.Pictures, options => options.MapFrom(so => so.Pictures));
        }

        private void MapPainterToDbPainter()
        {
            CreateMap<Painter, DbPainter>()
                .ForMember(de => de.PainterId, options => options.MapFrom(so => so.PainterId))
                .ForMember(de => de.PainterFullName, options => options.MapFrom(so => so.PainterFullName))
                .ForMember(de => de.Pictures, options => options.MapFrom(so => so.Pictures));
        }
    }
}
