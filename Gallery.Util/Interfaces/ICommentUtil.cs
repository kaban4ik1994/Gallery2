﻿using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface ICommentUtil : IUtil
    {
       Comment CreateComment(Comment comment);
       HttpStatusCode DeleteComment(long id);
    }
}
