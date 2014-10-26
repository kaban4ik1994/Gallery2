using AutoMapper;
using Gallery.Models.Models;
using Gallety.Entities;

namespace Gallery.Mappings.Mappings
{
    public class RoleMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            MapDbRoleToRole();
            MapRoleToDbRole();
          //  Mapper.AssertConfigurationIsValid();
        }

        private void MapDbRoleToRole()
        {
            CreateMap<DbRole, Role>()
                .ForMember(de => de.RoleId, options => options.MapFrom(so => so.RoleId))
                .ForMember(de => de.RoleName, options => options.MapFrom(so => so.RoleName))
                .ForMember(de => de.Users, options => options.MapFrom(so => so.Users));
        }

        private void MapRoleToDbRole()
        {
            CreateMap<Role, DbRole>()
                .ForMember(de => de.RoleId, options => options.MapFrom(so => so.RoleId))
                .ForMember(de => de.RoleName, options => options.MapFrom(so => so.RoleName))
                .ForMember(de => de.Users, options => options.MapFrom(so => so.Users));
        }
    }
}
