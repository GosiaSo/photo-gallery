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
        public string UploadImage(string filepath, string title, string description, string UserID)
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
                return "success";
            }
            catch (Exception) { }

            return "fail";
        }

        // api/Image/GetAll/{userId}
        [HttpGet(nameof(GetAll) + "/{UserImgId}", Name = nameof(GetAll))]
        public ActionResult<IEnumerable<ImageDTO>> GetAll(string UserImgId)
        {
            BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true", "galleryimages");

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

        // api/Image/GetImage/{userId & imgGUID}
        [HttpGet(nameof(GetImage) + "/{UserImgId}", Name = nameof(GetImage))]
        public ActionResult<IEnumerable<ImageDTO>> GetImage(string UserImgId, string imgGUID)
        {
            BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true", "galleryimages");

            return _dbContext.ImageEntities.Where(item => item.UserImgID == UserImgId && item.Id == imgGUID).Select(e => new ImageDTO
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

        // api/Image/Delete/{Id}
        [HttpDelete("Delete/{Id}", Name = nameof(Delete))]
        public void Delete(string Id)
        {

            var entity = _dbContext.ImageEntities.SingleOrDefault(e => e.Id == Id);

            if (entity != null)
            {
                BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true", "galleryimages");
                containerClient.GetBlobClient(entity.UserImgID + "/" + entity.Id).DeleteIfExists();

                _dbContext.ImageEntities.Remove(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}

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
