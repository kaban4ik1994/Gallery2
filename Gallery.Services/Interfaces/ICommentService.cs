using System.Collections.Generic;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<DbComment> GetComments();
        DbComment GetCommentById(long id);
        void CreateComment(DbComment comment);
        void UpdateComment(DbComment comment);
        void DeleteComment(long id);
        IEnumerable<DbComment> GetCommentsByPictureId(long id);
        void SaveComment();
    }
}
