﻿using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;

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
                .ForMember(de => de.DepartamentDescription,
                    options => options.MapFrom(so => so.DepartamentDescription))
                .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture));
        }

        private void MapDepartamentToDbDepartament()
        {
            CreateMap<Departament, DbDepartament>()
               .ForMember(de => de.DepartamentId, options => options.MapFrom(so => so.DepartamentId))
               .ForMember(de => de.DepartamentName, options => options.MapFrom(so => so.DepartamentName))
               .ForMember(de => de.DepartamentDescription,
                   options => options.MapFrom(so => so.DepartamentDescription))
               .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture));
        }
    }
}
