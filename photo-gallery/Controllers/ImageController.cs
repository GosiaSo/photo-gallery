using AuthDatabase;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ImageService _imageService;
        private readonly UserManager<AppUser> _userManager;

        public ImageController(ImageService imageService, UserManager<AppUser> userManager)
        {
            _imageService = imageService;
            _userManager = userManager;        
        }

        public async Task<IActionResult> Index()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            var images = await _imageService.GetImageAsync(currentUser.UserImgID);
            
            var model = new ImageViewModel()
            {
                Images = images
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(ImageItemViewModel newImage)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }

            _imageService.PostImageAsync(newImage, newImage.FilePath, currentUser.UserImgID);

            return RedirectToAction("Index");
        }
    }
}
