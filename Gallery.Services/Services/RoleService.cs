using System.Collections.Generic;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbRole> GetRoles()
        {
            var roles = _roleRepository.GetAll();
            return roles;
        }

        public DbRole GetRoleById(long id)
        {
            var role = _roleRepository.GetById(id);
            return role;
        }

        public void CreateRole(DbRole role)
        {
            _roleRepository.Add(role);
            _unitOfWork.Commit();
        }

        public void UpdateRole(DbRole role)
        {
            _roleRepository.Update(role);
            _unitOfWork.Commit();
        }

        public void DeleteRole(long id)
        {
            var role = _roleRepository.GetById(id);
            _roleRepository.Delete(role);
            _unitOfWork.Commit();
        }

        public void SaveRole()
        {
            _unitOfWork.Commit();
        }
    }
}
