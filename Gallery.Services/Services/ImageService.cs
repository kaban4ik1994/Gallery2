using System.Collections.Generic;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Services.Interfaces;
using Gallety.Entities;

namespace Gallery.Services.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbImage> GetImages()
        {
            var images = _imageRepository.GetAll();
            return images;
        }

        public DbImage GetImageById(long id)
        {
            var image = _imageRepository.GetById(id);
            return image;
        }

        public void CreateImage(DbImage image)
        {
            _imageRepository.Add(image);
            _unitOfWork.Commit();
        }

        public void UpdateImage(DbImage image)
        {
            _imageRepository.Update(image);
            _unitOfWork.Commit();
        }

        public void DeleteImage(long id)
        {
            var image = _imageRepository.GetById(id);
            _imageRepository.Delete(image);
            _unitOfWork.Commit();
        }

        public void SaveImage()
        {
            _unitOfWork.Commit();
        }
    }
}
