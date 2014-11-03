using System.IO;
using System.Linq;
using System.Web.Mvc;
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
                .ForMember(de => de.Pictures, options => options.Ignore())
                .ForMember(de => de.Images, options => options.MapFrom(so => so.Images));

        }

        private void MapPainterToPainterViewModel()
        {
            CreateMap<Painter, PainterViewModel>()
                .ForMember(de => de.Id, options => options.MapFrom(so => so.PainterId))
                .ForMember(de => de.Name, options => options.MapFrom(so => so.PainterFullName))
                .ForMember(de => de.Images, options => options.MapFrom(so => so.Images))
                .ForMember(de => de.FileImage, options => options.Ignore());
        }
    }
}