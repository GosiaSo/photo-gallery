using ImageDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDatabase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions opt) : base(opt)
        {

        }

        protected DatabaseContext()
        {

        }

        public virtual DbSet<ImageEntity> ImageEntities { get; set; }
    }
}
