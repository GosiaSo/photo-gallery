using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthDatabase
{
    public class AuthDatabaseContext : IdentityDbContext <AppUser>
    {
        // Jeśli jest kilka DbCotext, ważne aby w parametrze konstruktora przekazać 'DbContextOptions<ImageDatabaseContext> opt'
        public AuthDatabaseContext(DbContextOptions<AuthDatabaseContext> opt) : base(opt)
        {

        }
    }
}
