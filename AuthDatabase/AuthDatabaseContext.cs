using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthDatabase
{
    public class AuthDatabaseContext : IdentityDbContext <AppUser>
    {
        public AuthDatabaseContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}
