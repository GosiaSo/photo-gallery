using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_gallery.Security
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
    }
}
