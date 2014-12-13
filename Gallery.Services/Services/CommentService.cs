using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;
using Gallery.Services.Interfaces;

namespace Gallery.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DbComment> GetComments()
        {
            var comments = _commentRepository.GetAll();
            return comments;
        }

        public IEnumerable<DbComment> GetCommentsByPictureId(long id)
        {
            var comments = _commentRepository.GetAll().Include(x => x.User).Where(x => x.CommentPictureId==id);
            return comments;
        }

        public DbComment GetCommentById(long id)
        {
            var comment = _commentRepository.GetById(id);
            return comment;
        }

        public void CreateComment(DbComment comment)
        {
            _commentRepository.Add(comment);
            _unitOfWork.Commit();
        }

        public void UpdateComment(DbComment comment)
        {
            _commentRepository.Update(comment);
            _unitOfWork.Commit();
        }

        public void DeleteComment(long id)
        {
            var comment = _commentRepository.GetAll().First(x => x.CommentId==id);
            _commentRepository.Delete(comment);
            _unitOfWork.Commit();
        }

        public void SaveComment()
        {
            _unitOfWork.Commit();
        }
    }
}
