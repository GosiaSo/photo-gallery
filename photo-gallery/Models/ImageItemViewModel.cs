using WebApp.Services;

namespace WebApp.Models
{
    public class ImageItemViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string UserImgId { get; set; }
        public string FilePath { get; set; }
        public string imgURL { get; set; }


        internal ImageDTO ToImageDto()
        {
            ImageDTO returnValue = new ImageDTO();

            returnValue.Id = Id;
            returnValue.Title = Title;
            returnValue.Extension = Extension;
            returnValue.Date = Date;
            returnValue.Time = Time;
            returnValue.Description = Description;
            returnValue.imgURL = imgURL;

            return returnValue;
        }

        internal static ImageItemViewModel FromDto(ImageDTO dto)
        {
            ImageItemViewModel returnValue = new ImageItemViewModel();

            returnValue.Id = dto.Id;
            returnValue.Title = dto.Title;
            returnValue.Extension = dto.Extension;
            returnValue.Date = dto.Date;
            returnValue.Time = dto.Time;
            returnValue.Description = dto.Description;
            returnValue.imgURL = dto.imgURL;

            return returnValue;
        }
    }
}

