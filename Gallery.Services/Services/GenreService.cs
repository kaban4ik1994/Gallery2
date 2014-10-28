using System.Collections.Generic;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbGenre> GetGenres()
        {
            var genres = _genreRepository.GetAll();
            return genres;
        }

        public DbGenre GetGenreById(long id)
        {
            var genre = _genreRepository.GetById(id);
            return genre;
        }

        public void CreateGenre(DbGenre genre)
        {
            _genreRepository.Add(genre);
            _unitOfWork.Commit();
        }

        public void UpdateGenre(DbGenre genre)
        {
            _genreRepository.Update(genre);
            _unitOfWork.Commit();
        }

        public void DeleteGenre(long id)
        {
            var genre = _genreRepository.GetById(id);
            _genreRepository.Delete(genre);
            _unitOfWork.Commit();
        }

        public void SaveGenre()
        {
            _unitOfWork.Commit();
        }
    }
}
