using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IGenreUtil : IUtil
    {
        Genre GetGenreById(long id);
        Genre CreateGenre(Genre genre);
        Genre UpdateGenre(Genre genre);
        HttpStatusCode DeleteGenre(long id);
    }
}
