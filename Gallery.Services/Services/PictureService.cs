using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PictureService(IPictureRepository pictureRepository, IUnitOfWork unitOfWork)
        {
            _pictureRepository = pictureRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbPicture> GetPictures()
        {
            var pictures = _pictureRepository.GetAll().Include(x => x.Images);
            return pictures;
        }

        public DbPicture GetPictureById(long id)
        {
            var picture = _pictureRepository.GetMany(x => x.PictureId == id).Include(x => x.Genre).Include(x => x.Painter).Include(x => x.DbDepartament).Include(x => x.Comments).Include(x=>x.Images).FirstOrDefault();
            return picture;
        }

        public DbPicture GetPictureByName(string name)
        {
            var picture = _pictureRepository.GetMany(x => x.PictureName == name).FirstOrDefault();
            return picture;
        }

        public void CreatePicture(DbPicture picture)
        {
            _pictureRepository.Add(picture);
            _unitOfWork.Commit();
        }

        public void UpdatePicture(DbPicture picture)
        {
            _pictureRepository.Update(picture);
        }

        public void DeletePicture(long id)
        {
            var picture = _pictureRepository.GetById(id);
            _pictureRepository.Delete(picture);
            _unitOfWork.Commit();
        }

        public void SavePicture()
        {
            _unitOfWork.Commit();
        }
    }
}
