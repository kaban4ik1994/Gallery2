using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartamentService(IDepartamentRepository departamentRepository, IUnitOfWork unitOfWork)
        {
            _departamentRepository = departamentRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbDepartament> GetDepartaments()
        {
            var departaments = _departamentRepository.GetAll();
            return departaments;
        }

        public DbDepartament GetDepartamentById(long id)
        {
            var departament = _departamentRepository.GetById(id);
            return departament;
        }

        public DbDepartament GetDepartamentByName(string name)
        {
            var departament = _departamentRepository.GetAll().Include(x => x.Picture).FirstOrDefault(x => x.DepartamentName==name);
            return departament;
        }

        public void CreateDepartament(DbDepartament departament)
        {
            _departamentRepository.Add(departament);
            _unitOfWork.Commit();
        }

        public void UpdateDepartament(DbDepartament departament)
        {
            _departamentRepository.Update(departament);
            _unitOfWork.Commit();
        }

        public void DeleteDepartament(long id)
        {
            var departament = _departamentRepository.GetById(id);
            _departamentRepository.Delete(departament);
            _unitOfWork.Commit();
        }

        public void SaveDepartament()
        {
            _unitOfWork.Commit();
        }
    }
}
