using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IPainterUtil : IUtil
    {
        Painter GetPainterById(long id);
        Painter CreatePainter(Painter painter);
        Painter UpdatePainter(Painter painter);
        HttpStatusCode DeletePainter(long id);
    }
}
