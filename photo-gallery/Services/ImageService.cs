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

        // inter
        public async void PostImageAsync(ImageItemViewModel image, string filepath, string UserImgId)
        {
            ImageWebApiClient api = new ImageWebApiClient(url, http);

            await api.UploadImageAsync(filepath, image.Title, image.Description, UserImgId);
        }

        // inter
        public async Task<ImageItemViewModel[]> GetImageAsync(string UserImgId)
        {
            ImageWebApiClient api = new ImageWebApiClient(url, http);
            var dtoImage = await api.GetAllAsync(UserImgId);
            return dtoImage.Select(dto => ImageItemViewModel.FromDto(dto)).ToArray();
        }

        // inter
        public async void DeleteImageAsync(string imageId)
        {
            ImageWebApiClient api = new ImageWebApiClient(url, http);
            await api.DeleteAsync(imageId);
        }

        public async Task<ImageItemViewModel[]> EnlargeImageAsync(string UserImgId, string imageId)
        {
            ImageWebApiClient api = new ImageWebApiClient(url, http);
            var dtoImage = await api.GetImageAsync(UserImgId, imageId);
            return dtoImage.Select(dto => ImageItemViewModel.FromDto(dto)).ToArray();
        }
    }
}
