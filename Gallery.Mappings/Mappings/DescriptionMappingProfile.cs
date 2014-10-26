using AutoMapper;
using Gallery.Models.Models;
using Gallety.Entities;

namespace Gallery.Mappings.Mappings
{
    public class DescriptionMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbDescriptionToDescription();
            MapDescriptionToDbDescription();
           // Mapper.AssertConfigurationIsValid();
        }

        private void MapDbDescriptionToDescription()
        {
            CreateMap<DbDescription, Description>()
                .ForMember(de => de.DescriptionId, options => options.MapFrom(so => so.DescriptionId))
                .ForMember(de => de.DescriptionContent, options => options.MapFrom(so => so.Description))
                .ForMember(de => de.DescriptionDepartamentId,
                    options => options.MapFrom(so => so.DescriptionDepartamentId))
                .ForMember(de => de.Departament, options => options.MapFrom(so => so.Departament));
        }

        private void MapDescriptionToDbDescription()
        {
            CreateMap<Description, DbDescription>()
                .ForMember(de => de.DescriptionId, options => options.MapFrom(so => so.DescriptionId))
                .ForMember(de => de.Description, options => options.MapFrom(so => so.DescriptionContent))
                .ForMember(de => de.DescriptionDepartamentId,
                    options => options.MapFrom(so => so.DescriptionDepartamentId))
                .ForMember(de => de.Departament, options => options.MapFrom(so => so.Departament));
        }
    }
}
