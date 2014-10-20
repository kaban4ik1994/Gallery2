using System.Collections.Generic;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Services.Interfaces;
using Gallety.Entities;

namespace Gallery.Services.Services
{
    public class PainterService: IPainterService
    {
        private readonly IPainterRepository _painterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PainterService(IPainterRepository painterRepository, IUnitOfWork unitOfWork)
        {
            _painterRepository = painterRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbPainter> GetPainters()
        {
            var painters = _painterRepository.GetAll();
            return painters;
        }

        public DbPainter GetPainterById(long id)
        {
            var painter = _painterRepository.GetById(id);
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
