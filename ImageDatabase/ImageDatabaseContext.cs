using ImageDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageDatabase
{
    public class ImageDatabaseContext : DbContext
    {
        // Jeśli jest kilka DbCotext, ważne aby w parametrze konstruktora przekazać 'DbContextOptions<ImageDatabaseContext> opt'
        public ImageDatabaseContext(DbContextOptions<ImageDatabaseContext> opt) : base(opt)
        {

        }

        public virtual DbSet<ImageEntity> ImageEntities { get; set; }
    }
}
