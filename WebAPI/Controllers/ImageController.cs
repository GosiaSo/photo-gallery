using Azure.Storage.Blobs;
using ImageDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAPI.Models;
using Azure.Storage.Sas;

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

        // api/Image/UploadImage
        [HttpPost(nameof(UploadImage), Name = nameof(UploadImage))]
        public void UploadImage(string filepath, string title, string description, string UserID)
        {
            BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true", "galleryimages");
            try
            {
                string imgGUID = Guid.NewGuid().ToString();
                
                BlobClient blobClient = containerClient.GetBlobClient(UserID + "/" + imgGUID);
                using FileStream fileStream = System.IO.File.OpenRead(filepath);
                {
                    blobClient.Upload(fileStream);
                }
                _dbContext.ImageEntities.Add(new ImageDatabase.Entities.ImageEntity
                {
                    Id = imgGUID,
                    Extension = Path.GetExtension(filepath),
                    Title = title,
                    Date = DateTime.Today.ToString("MM/dd/yyyy"),
                    Time = DateTime.Now.ToString("hh:mm tt"),
                    Description = description,
                    UserImgID = UserID
                });
                _dbContext.SaveChanges();
            }
            catch (Exception) { }
        }

        // api/Image/GetAll/{userId}
        [HttpGet(nameof(GetAll) + "/{UserImgId}", Name = nameof(GetAll))]
        public ActionResult<IEnumerable<ImageDTO>> GetAll(string UserImgId)
        {
            BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true", "galleryimages");

            //get the container url here
            string container_url = containerClient.Uri.ToString();

            return _dbContext.ImageEntities.Where(item => item.UserImgID == UserImgId).Select(e => new ImageDTO
            {
                Id = e.Id,
                Extension = e.Extension,
                Title = e.Title,
                Date = e.Date,
                Time = e.Time,
                Description = e.Description,
                imgURL = containerClient.GetBlobClient(UserImgId + "/" + e.Id).GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.Now.AddHours(1)).ToString()
            }).ToList();
        }
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
    //        Description = e.Description
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
