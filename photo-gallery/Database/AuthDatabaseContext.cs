using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using photo_gallery.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_gallery.Database
{
    public class AuthDatabaseContext : IdentityDbContext<User>

    {
        public AuthDatabaseContext(DbContextOptions opt) : base(opt)
        {
        }

    }
}
