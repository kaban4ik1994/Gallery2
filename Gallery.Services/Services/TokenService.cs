using System.Collections.Generic;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class TokenService : ITokenSevice
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(ITokenRepository tokenRepository, IUnitOfWork unitOfWork)
        {
            _tokenRepository = tokenRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbToken> GetTokens()
        {
            var tokens = _tokenRepository.GetAll();
            return tokens;
        }

        public DbToken GetTokenById(long id)
        {
            var token = _tokenRepository.GetById(id);
            return token;
        }

        public void CreateToken(DbToken token)
        {
            _tokenRepository.Add(token);
            _unitOfWork.Commit();
        }

        public void UpdateToken(DbToken token)
        {
            _tokenRepository.Update(token);
            _unitOfWork.Commit();
        }

        public void DeleteToken(long id)
        {
            var token = _tokenRepository.GetById(id);
            _tokenRepository.Delete(token);
            _unitOfWork.Commit();
        }

        public void SaveToken()
        {
            _unitOfWork.Commit();
        }
    }
}
