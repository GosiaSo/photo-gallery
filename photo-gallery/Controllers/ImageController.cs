using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly UserManager<AppUser> _userManager;

        public async Task<IActionResult> Index()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            var images = await _imageService.GetImageAsync(currentUser.Id);
            
            var model = new ImageViewModel()
            {
                Images = images
            };

            return View(model);
        }
    }
}
