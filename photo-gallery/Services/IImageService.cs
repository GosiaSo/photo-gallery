﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IImageService
    {
        Task<Guid>  AddImageAsync(ImageItemViewModel image, string UserId);
        Task<ImageItemViewModel[]> GetImageAsync(string userId);
    }
}
