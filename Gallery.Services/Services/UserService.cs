using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbUser> GetUsers()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public DbUser GetUserById(long id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public DbUser GetUserByEmailAndPasswordHash(string email, string passwordHash)
        {
            var user = _userRepository.GetMany(x => x.Email == email && x.PasswordHash == passwordHash).FirstOrDefault();
            return user;
        }

        public DbUser GetUserByEmail(string email)
        {
            var user = _userRepository.GetMany(x=>x.Email==email).Include(x=>x.Tokens).Include(x=>x.Role).Include(x=>x.DbComments).FirstOrDefault();
            return user;
        }

        public void CreateUser(DbUser user)
        {
            _userRepository.Add(user);
            _unitOfWork.Commit();
        }

        public void UpdateUser(DbUser user)
        {
            _userRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(long id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
            _unitOfWork.Commit();
        }

        public void SaveUser()
        {
            _unitOfWork.Commit();
        }
    }
}
