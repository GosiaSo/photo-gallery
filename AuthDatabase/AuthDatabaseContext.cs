using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AuthDatabase;

namespace AuthDatabase
{
    public class AuthDatabaseContext : IdentityDbContext <AppUser>
    {
        public AuthDatabaseContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}
