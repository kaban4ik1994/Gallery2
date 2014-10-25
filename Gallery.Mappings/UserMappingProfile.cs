using AutoMapper;
using Gallery.ModelsAPI;
using Gallety.Entities;

namespace Gallery.Mappings
{
    public class UserMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbUserToUser();
            MapUserToDbUser();
            Mapper.AssertConfigurationIsValid();
        }

        private void MapDbUserToUser()
        {
            CreateMap<DbUser, User>()
                .ForMember(de => de.UserId, options => options.MapFrom(so => so.UserId))
                .ForMember(de => de.UserName, options => options.MapFrom(so => so.UserName))
                .ForMember(de => de.Email, options => options.MapFrom(so => so.Email))
                .ForMember(de => de.PasswordHash, options => options.MapFrom(so => so.PasswordHash))
                .ForMember(de => de.UserRoleId, options => options.MapFrom(so => so.UserRoleId))
                .ForMember(de => de.Role, options => options.MapFrom(so => so.Role))
                .ForMember(de => de.Comments, options => options.MapFrom(so => so.DbComments));
        }

        private void MapUserToDbUser()
        {
            CreateMap<User, DbUser>()
                .ForMember(de => de.UserId, options => options.MapFrom(so => so.UserId))
                .ForMember(de => de.UserName, options => options.MapFrom(so => so.UserName))
                .ForMember(de => de.Email, options => options.MapFrom(so => so.Email))
                .ForMember(de => de.PasswordHash, options => options.MapFrom(so => so.PasswordHash))
                .ForMember(de => de.UserRoleId, options => options.MapFrom(so => so.UserRoleId))
                .ForMember(de => de.Role, options => options.MapFrom(so => so.Role))
                .ForMember(de => de.DbComments, options => options.MapFrom(so => so.Comments));
        }
    }

}
