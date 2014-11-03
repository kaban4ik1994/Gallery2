using System.Collections.Generic;
using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IGenreUtil : IUtil
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(long id);
        Genre GetGenreByName(string name);
        Genre CreateGenre(Genre genre);
        Genre UpdateGenre(Genre genre);
        HttpStatusCode DeleteGenre(long id);
    }
}
