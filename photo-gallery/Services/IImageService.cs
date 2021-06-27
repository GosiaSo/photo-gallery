using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    interface IImageService
    {
        Task<Guid> AddItemAsync(ImageItemViewModel item, string userId);
        Task<ImageItemViewModel[]> GetItemsAsync(string ownerId);
    }
}
