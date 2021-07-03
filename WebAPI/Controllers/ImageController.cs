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
    [Produces("application/json")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        ImageDatabaseContext _dbContext;

        public ImageController(ImageDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // api/Image/{id}
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<ImageDTO>> Get(string userId)
        {
            return _dbContext.ImageEntities.Where(item => item.UserId == userId).Select(e => new ImageDTO
            {
                Id = e.Id,
                Title = e.Title,
                ImageUrl = e.ImageUrl,
                Date = e.Date,
                Time = e.Time,
                Comment = e.Comment
            }).ToList();
        }


        // 
        [HttpPost]
        public ActionResult<Guid> Post([FromBody]ImageDTO value)
        {
            Guid id = Guid.NewGuid();
            _dbContext.ImageEntities.Add(new ImageDatabase.Entities.ImageEntity
            {
                Id = id,
                Title = value.Title,
                ImageUrl = value.ImageUrl,
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Time = DateTime.Now.ToString("hh:mm tt"),
        Comment = value.Comment,
                UserId = value.UserId
            });
            _dbContext.SaveChanges();
            return id;
        }

        //
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ImageDTO value)
        {
            var entity = _dbContext.ImageEntities.SingleOrDefault(e => e.Id == id);

            if (entity != null)
            {
                entity.Date = value.Date;
                entity.Time = value.Time;
                _dbContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id, [FromBody] ImageDTO value)
        {
            var entity = _dbContext.ImageEntities.SingleOrDefault(e => e.Id == id);

            if (entity != null)
            {
                _dbContext.ImageEntities.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

    }
}
