using System.Collections.Generic;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<DbGenre> GetGenres();
        DbGenre GetGenreById(long id);
        DbGenre GetGenreByName(string name);
        void CreateGenre(DbGenre genre);
        void UpdateGenre(DbGenre genre);
        void DeleteGenre(long id);
        void SaveGenre();
    }
}
