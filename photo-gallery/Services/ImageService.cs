using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class ImageService : IImageService
    {
        string url = "http://localhost:28143";

        HttpClient http = new HttpClient();

        // inter
        public async Task<Guid> AddImageAsync(ImageItemViewModel image, string UserId)
        {
            ImageWebApiClient apiClient = new ImageWebApiClient(url, http);

            image.UserId = UserId;
           

            Guid returnValue = await apiClient.ImageAsync(image.ToImageDto());

            return returnValue;
        }

        /// inter
        public async Task<ImageItemViewModel[]> GetImageAsync(string userId)
        {
            ImageWebApiClient apiClient = new ImageWebApiClient(url, http);
            var dtoImage = await apiClient.ImageAllAsync(userId);
            return dtoImage.Select(dto => ImageItemViewModel.FromDto(dto)).ToArray();
        }

        //public async Task<ImageItemViewModel> GetImageAsync(string userId)
        //{
        //    ImageWebApiClient apiClient = new ImageWebApiClient(url, http);
        //    var dtoImages = await apiClient.ImageAllAsync(userId);
        //    return returnValue;
        //}

    }
}
