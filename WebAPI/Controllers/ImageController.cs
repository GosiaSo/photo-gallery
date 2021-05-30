using ImageDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/json")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        DatabaseContext _dbContext;

        public ImageController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // api/photo-gallery/id
        [HttpGet("{ownerId}")]
        public ActionResult<IEnumerable<ImageDTO>> Get(string ownerId)
        {
            _dbContext.ImageEntities.Where(item => item.OwnerId == ownerId).Select(e => new ImageDTO
            {
                Id = e.Id,
                Title = e.Title,
                ImageUrl = e.ImageUrl,
                Date = e.Date,
                Time = e.Time
            }).ToList();
        }


    }
}
