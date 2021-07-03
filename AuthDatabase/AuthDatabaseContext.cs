using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthDatabase
{
    public class AuthDatabaseContext : IdentityDbContext <AppUser>
    {
        public AuthDatabaseContext(DbContextOptions<AuthDatabaseContext> opt) : base(opt)
        {

        }
    }
}
