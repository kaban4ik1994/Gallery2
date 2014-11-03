using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class PainterService : IPainterService
    {
        private readonly IPainterRepository _painterRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PainterService(IPainterRepository painterRepository, IUnitOfWork unitOfWork)
        {
            _painterRepository = painterRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbPainter> GetPainters()
        {
            var painters = _painterRepository.GetAll().Include(x => x.Images);
            return painters;
        }

        public DbPainter GetPainterById(long id)
        {
            var painter = _painterRepository.GetMany(x => x.PainterId == id).Include(x => x.Images).FirstOrDefault();
            return painter;
        }

        public DbPainter GetPainterByName(string name)
        {
            var painter = _painterRepository.GetMany(x => x.PainterFullName == name).FirstOrDefault();
            return painter;

        }

        public void CreatePainter(DbPainter painter)
        {
            _painterRepository.Add(painter);
            _unitOfWork.Commit();
        }

        public void UpdatePainter(DbPainter painter)
        {
            _painterRepository.Update(painter);
            _unitOfWork.Commit();
        }

        public void DeletePainter(long id)
        {
            var painter = _painterRepository.GetById(id);
            _painterRepository.Delete(painter);
            _unitOfWork.Commit();
        }

        public void SavePainter()
        {
            _unitOfWork.Commit();
        }
    }
}
