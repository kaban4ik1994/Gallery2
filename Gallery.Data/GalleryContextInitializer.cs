using System.Collections.Generic;
using System.Data.Entity;
using Gallery.Entities;

namespace Gallery.Data
{
    public class GalleryContextInitializer : DropCreateDatabaseIfModelChanges<GalleryContext>
    {
        protected override void Seed(GalleryContext context)
        {
           
            var roles = new List<DbRole>
            {
                new DbRole {RoleId = 1, RoleName = "admin"},
                new DbRole {RoleId = 2, RoleName = "user"}
            };

            var admin = new DbUser
            {
                Email = "admin@mail.ru",
                UserRoleId = 1,
                UserName = "admin",
                PasswordHash = "370a4f35a10779834b69da960176d5a6",
                UserId = 1
            };

            foreach (var dbRole in roles)
            {
                context.Roles.Add(dbRole);
            }
            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}
