using System.Data.Entity;
using Gallety.Entities;

namespace Gallery.Data
{
    public class GalleryContext: DbContext
    {
        public GalleryContext():base("GalleryDataBase")
        {
        }

        public DbSet<DbComment> Comments { get; set; }
        public DbSet<DbDepartament> Departaments { get; set; }
        public DbSet<DbDescription> Descriptions { get; set; }
        public DbSet<DbGenre> Genres { get; set; }
        public DbSet<DbImage> Images { get; set; }
        public DbSet<DbPainter> Painters { get; set; }
        public DbSet<DbPicture> Pictures { get; set; }
        public DbSet<DbRole> Roles { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbToken> Tokens { get; set; } 

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
