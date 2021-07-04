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



        internal ImageDTO ToImageDto()
        {
            ImageDTO returnValue = new ImageDTO();

            returnValue.Id = Id;
            returnValue.Title = Title;
            returnValue.Extension = Extension;
            returnValue.Date = Date;
            returnValue.Time = Time;
            returnValue.Description = Description;

            return returnValue;
        }

        internal static ImageItemViewModel FromDto(ImageDTO dto)
        {
            ImageItemViewModel returnValue = new ImageItemViewModel();

            returnValue.Id = dto.Id;
            returnValue.Title = dto.Title;
            returnValue.Date = dto.Date;
            returnValue.Description = dto.Description;

            return returnValue;
        }
    }
}

