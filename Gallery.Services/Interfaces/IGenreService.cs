using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallety.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<DbGenre> GetGenres();
        DbGenre GetGenreById(long id);
        void CreateGenre(DbGenre genre);
        void UpdateGenre(DbGenre genre);
        void DeleteGenre(long id);
        void SaveGenre();
    }
}
