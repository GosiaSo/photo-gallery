using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class IImageService
    {
        Task<ImageItemViewModel[]> GetPhotosAsync(string UserId);
    }
}
