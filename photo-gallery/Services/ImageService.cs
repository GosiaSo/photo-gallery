using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class ImageService
    {
        string url = "http://localhost:28143";

        HttpClient http = new HttpClient();

        public async Task<Guid> AddImageAsync(ImageItemViewModel image, string userId, string title)
        {
            ImageWebApiClient apiClient = new ImageWebApiClient(url, http);

            item.UserId = userId;
            item.Title = title;

            Guid returnValue = await apiClient.ImageAsync(item.ToImageDto());

            return returnValue;
        }

        public async Task<ImageItemViewModel> GetImageAsync(string userId)
        {
            ImageWebApiClient apiClient = new ImageWebApiClient(url, http);
            var dtoImages = await apiClient.ImageAllAsync(userId);
            return returnValue;
        }

        public async Task<ImageItemViewModel[]> GetItemsAsync(string userId)
        {
            ImageWebApiClient apiClient = new ImageWebApiClient(url, http);
            var dtoItems = await apiClient.ImageAllAsync(userId);
            return dtoItems.Select(dto => ImageItemViewModel.FromDto(dto)).ToArray();
        }
    }
}
