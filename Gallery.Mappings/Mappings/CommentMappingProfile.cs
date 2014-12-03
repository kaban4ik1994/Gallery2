using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;

namespace Gallery.Mappings.Mappings
{
    public class CommentMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapCommentToDbComment();
            MapDbCommentToComment();
            //  Mapper.AssertConfigurationIsValid();
        }

        private void MapDbCommentToComment()
        {
            CreateMap<DbComment, Comment>()
                .ForMember(de => de.CommentId, options => options.MapFrom(so => so.CommentId))
                .ForMember(de => de.CreatedDate, options => options.MapFrom(so => so.CreatedDate))
                .ForMember(de => de.Content, options => options.MapFrom(so => so.Content))
                .ForMember(de => de.CommentPictureId, options => options.MapFrom(so => so.CommentPictureId))
                .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture))
                .ForMember(de => de.CommentUserId, options => options.MapFrom(so => so.CommentUserId))
                .ForMember(de => de.User, options => options.MapFrom(so => so.User));

        }

        private void MapCommentToDbComment()
        {
            CreateMap<Comment, DbComment>()
                .ForMember(de => de.CommentId, options => options.MapFrom(so => so.CommentId))
                .ForMember(de => de.CreatedDate, options => options.MapFrom(so => so.CreatedDate))
                .ForMember(de => de.Content, options => options.MapFrom(so => so.Content))
                .ForMember(de => de.CommentPictureId, options => options.MapFrom(so => so.CommentPictureId))
                .ForMember(de => de.Picture, options => options.MapFrom(so => so.Picture))
                .ForMember(de => de.CommentUserId, options => options.MapFrom(so => so.CommentUserId))
                .ForMember(de => de.User, options => options.MapFrom(so => so.User));
        }
    }
}
