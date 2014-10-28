﻿using AutoMapper;
using Gallery.Models.Models;
using Gallety.Entities;

namespace Gallery.Mappings.Mappings
{
    public class DepartamentMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbDepartamentToDepartament();
            MapDepartamentToDbDepartament();
          // Mapper.AssertConfigurationIsValid();
        }

        private void MapDbDepartamentToDepartament()
        {
            CreateMap<DbDepartament, Departament>()
                .ForMember(de => de.DepartamentId, options => options.MapFrom(so => so.DepartamentId))
                .ForMember(de => de.DepartamentName, options => options.MapFrom(so => so.DepartamentName))
                .ForMember(de => de.DepartamentNumber, options => options.MapFrom(so => so.DepartamentNumber))
                .ForMember(de => de.DepartamentDescriptionId,
                    options => options.MapFrom(so => so.DepartamentDescriptionId))
                .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture));
        }

        private void MapDepartamentToDbDepartament()
        {
            CreateMap<Departament, DbDepartament>()
               .ForMember(de => de.DepartamentId, options => options.MapFrom(so => so.DepartamentId))
               .ForMember(de => de.DepartamentName, options => options.MapFrom(so => so.DepartamentName))
               .ForMember(de => de.DepartamentNumber, options => options.MapFrom(so => so.DepartamentNumber))
               .ForMember(de => de.DepartamentDescriptionId,
                   options => options.MapFrom(so => so.DepartamentDescriptionId))
               .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture));
        }
    }
}