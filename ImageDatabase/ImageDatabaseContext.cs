using ImageDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageDatabase
{
    public class ImageDatabaseContext : DbContext
    {
        public ImageDatabaseContext(DbContextOptions<ImageDatabaseContext> opt) : base(opt)
        {

        }

        public virtual DbSet<ImageEntity> ImageEntities { get; set; }
    }
}
