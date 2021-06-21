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

        public async Task<Guid> AddItemAsync(ImageItemViewModel item, string userId, string title)
        {
            ImageWebApiClient apiClient = new ImageWebApiClient(url, http);

            item.UserId = userId;
            item.Title = title;

            Guid returnValue = await apiClient.ImageAsync(item.ImageDTO());

            return returnValue;
        }

       
    }
}
