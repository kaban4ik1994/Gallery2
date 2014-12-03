using System.Data.Entity;
using Gallery.Entities;

namespace Gallery.Data
{
    public class GalleryContext : DbContext
    {
        public GalleryContext()
            : base("GalleryDBConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<DbPainter>()
                .HasMany(p => p.Pictures)
                .WithRequired()
                .HasForeignKey(p => p.PicturePainterId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<DbPicture>()
                .HasMany(p => p.Images)
                .WithRequired()
                .HasForeignKey(p => p.ImagePictureId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<DbPicture>()
                .HasMany(p => p.Comments)
                .WithRequired()
                .HasForeignKey(p => p.CommentPictureId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<DbGenre>()
               .HasMany(p => p.Pictures)
               .WithRequired()
               .HasForeignKey(p => p.PictureGenreId)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<DbDepartament>()
               .HasMany(p => p.Picture)
               .WithRequired()
               .HasForeignKey(p => p.PictureDepartamentId)
               .WillCascadeOnDelete(true);
        }

        public DbSet<DbComment> Comments { get; set; }
        public DbSet<DbDepartament> Departaments { get; set; }
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
