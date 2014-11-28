using AutoMapper;
using Gallery.Models.Models;
using Gallery.WebUI.Models.Painter;

namespace Gallery.WebUI.Mappings
{
    public class PainterMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapPainterToPainterViewModel();
            MapPainterViewModelToPainter();
        }

        private void MapPainterViewModelToPainter()
        {
            CreateMap<PainterViewModel, Painter>()
                .ForMember(de => de.PainterId, options => options.MapFrom(so => so.Id))
                .ForMember(de => de.PainterFullName, options => options.MapFrom(so => so.Name))
                .ForMember(de => de.Pictures, options => options.Ignore());

        }

        private void MapPainterToPainterViewModel()
        {
            CreateMap<Painter, PainterViewModel>()
                .ForMember(de => de.Id, options => options.MapFrom(so => so.PainterId))
                .ForMember(de => de.Name, options => options.MapFrom(so => so.PainterFullName));
        }
    }
}