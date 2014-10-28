using System.Collections.Generic;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class DescriptionService : IDescriptionService
    {
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DescriptionService(IDescriptionRepository descriptionRepository, IUnitOfWork unitOfWork)
        {
            _descriptionRepository = descriptionRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbDescription> GetDescriptions()
        {
            var descriptions = _descriptionRepository.GetAll();
            return descriptions;
        }

        public DbDescription GetDescriptionById(long id)
        {
            var description = _descriptionRepository.GetById(id);
            return description;
        }

        public void CreateDescription(DbDescription description)
        {
            _descriptionRepository.Add(description);
            _unitOfWork.Commit();
        }

        public void UpdateDescription(DbDescription description)
        {
            _descriptionRepository.Update(description);
            _unitOfWork.Commit();
        }

        public void DeleteDescription(long id)
        {
            var description = _descriptionRepository.GetById(id);
            _descriptionRepository.Delete(description);
            _unitOfWork.Commit();
        }

        public void SaveDescription()
        {
            _unitOfWork.Commit();
        }
    }
}
