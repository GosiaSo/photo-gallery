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


        public async Task<IActionResult> Index()
        {
            var image = await _imageService.GetPhotosAsync();
            var model = new ImagesViewModel();
            {
                Images = images;
            };

            return View(model);
        }
        public IActionResult Index()
        {
            return View(new ImagesViewModel());
        }
    }
}
