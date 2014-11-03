using System.Collections.Generic;
using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IPainterUtil : IUtil
    {
        IEnumerable<Painter> GetPainters();
        Painter GetPainterById(long id);
        Painter GetPainterByName(string name);
        Painter CreatePainter(Painter painter);
        Painter UpdatePainter(Painter painter);
        HttpStatusCode DeletePainter(long id);
    }
}
