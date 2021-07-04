namespace WebApp.Models
{
    public class ImageViewModel
    {
        public ImageItemViewModel[] Images { get; set; }

        public ImageViewModel()
        {
            Images = new ImageItemViewModel[0];
        }
    }
}
