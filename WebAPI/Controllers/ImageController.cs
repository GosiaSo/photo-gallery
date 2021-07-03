using Azure.Storage.Blobs;
using ImageDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [HttpPost("upload/{filepath}")]
        public void UploadImage(string filepath, string title, string comment, string UserID)
        {
            BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true", "galleryimages");
                try
                {
                    string imgGUID = Guid.NewGuid().ToString();
                    BlobClient blobClient = containerClient.GetBlobClient(imgGUID);
                    using FileStream fileStream = System.IO.File.OpenRead(filepath);
                    {
                        blobClient.Upload(fileStream);
                    }
                    Guid id = Guid.NewGuid();
                    _dbContext.ImageEntities.Add(new ImageDatabase.Entities.ImageEntity
                    {
                        Id = imgGUID,
                        Extension = Path.GetExtension(filepath),
                        Title = title,
                        Date = DateTime.Today.ToString("MM/dd/yyyy"),
                        Time = DateTime.Now.ToString("hh:mm tt"),
                        Comment = comment,
                        UserImgID = UserID
                    });
                    _dbContext.SaveChanges();
            }
            catch (Exception) { }
        }

        // api/Image/get/{imgname}
        [HttpGet("get/{imgname}")]
        public ActionResult<string> GetImageUrl(string imgname)
        {

            BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true", "galleryimages");

            //get the container url here
            string container_url = containerClient.Uri.ToString();

            return container_url+"/"+imgname;
        }

        // api/Image/{id}
        //[HttpGet("{userId}")]
        //public ActionResult<IEnumerable<ImageDTO>> Get(string userId)
        //{
        //    return _dbContext.ImageEntities.Where(item => item.UserId == userId).Select(e => new ImageDTO
        //    {
        //        Id = e.Id,
        //        Title = e.Title,
        //        ImageUrl = e.ImageUrl,
        //        Date = e.Date,
        //        Time = e.Time,
        //        Comment = e.Comment
        //    }).ToList();
        //}

        // api/Image/upload/{filepath}

        //
        //[HttpPut("{id}")]
        //public void Put(Guid id, [FromBody] ImageDTO value)
        //{
        //    var entity = _dbContext.ImageEntities.SingleOrDefault(e => e.Id == id);

        //    if (entity != null)
        //    {
        //        entity.Date = value.Date;
        //        entity.Time = value.Time;
        //        _dbContext.SaveChanges();
        //    }
        //}

        //
        //[HttpDelete("{id}")]
        //public void Delete(Guid id, [FromBody] ImageDTO value)
        //{
        //    var entity = _dbContext.ImageEntities.SingleOrDefault(e => e.Id == id);

        //    if (entity != null)
        //    {
        //        _dbContext.ImageEntities.Remove(entity);
        //        _dbContext.SaveChanges();
        //    }
        //}

    }
}
