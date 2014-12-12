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

            for (var i = 0; i < 15; i++)
            {
                context.Genres.Add(new DbGenre{GenreName = "Genre"+i});
                context.Painters.Add(new DbPainter {PainterFullName = "Painter" + i});
                context.Departaments.Add(new DbDepartament
                {
                    DepartamentName = "Departament" + i,
                    DepartamentDescription = "Description" + i
                });
            }

            foreach (var dbRole in roles)
            {
                context.Roles.Add(dbRole);
            }
            context.Users.Add(admin);

            context.Database.ExecuteSqlCommand(
                "CREATE TRIGGER trg_UpdateTimeEntry ON dbo.Comments AFTER INSERT AS UPDATE dbo.Comments SET CreatedDate = GETDATE() WHERE CommentId IN (SELECT DISTINCT CommentId FROM Inserted)");

            context.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [GetPictureById] (@PictureId INT) AS SELECT  E.PictureId, E.PictureName, E.PictureGenreId, E.PicturePainterId, E.PictureDepartamentId FROM [dbo].[Pictures] E WHERE  E.PictureId = @PictureId RETURN");

            context.SaveChanges();
        }
    }
}
