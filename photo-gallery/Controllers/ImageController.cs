﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View(new ImagesViewModel());
        }
    }
}
