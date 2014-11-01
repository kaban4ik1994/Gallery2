using AutoMapper;
using Gallery.Models.Models;
using Gallery.WebUI.Models.Departament;

namespace Gallery.WebUI.Mappings
{
    public class DepartamentMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDepartamentViewModelToDepartament();
            MapDepartamentToDepartamentViewModel();
        }

        private void MapDepartamentViewModelToDepartament()
        {
            CreateMap<DepartamentViewModel, Departament>()
                .ForMember(de => de.DepartamentId, options => options.MapFrom(so => so.Id))
                .ForMember(de => de.DepartamentName, options => options.MapFrom(so => so.Name))
                .ForMember(de => de.DepartamentDescription, options => options.MapFrom(so => so.Description))
                .ForMember(de => de.Picture, options => options.Ignore());
        }

        private void MapDepartamentToDepartamentViewModel()
        {
            CreateMap<Departament, DepartamentViewModel>()
                .ForMember(de => de.Id, options => options.MapFrom(so => so.DepartamentId))
                .ForMember(de => de.Name, options => options.MapFrom(so => so.DepartamentName))
                .ForMember(de => de.Description, options => options.MapFrom(so => so.DepartamentDescription));
        }
    }
}