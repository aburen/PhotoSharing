using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhotoSharing.DAL.Entities;

namespace PhotoSharing.DAL.Context
{
    public class PhotoSharingContext:DbContext
    {
        public DbSet<FileImage> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public PhotoSharingContext(string connectionString)
        {
            Database.SetInitializer<PhotoSharingContext>(new PhotoSharingContextInitializer());
        }
    }
    public class PhotoSharingContextInitializer : DropCreateDatabaseIfModelChanges<PhotoSharingContext>
    {
        protected override void Seed(PhotoSharingContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName="Nature"},
                new Category(){CategoryName="Cars"},
                new Category(){CategoryName="People"},
                new Category(){CategoryName="Events"},
                new Category(){CategoryName="Food"},
                new Category(){CategoryName="Trains"}
            };
            context.Categories.AddRange(categories);
        }
    }
}
