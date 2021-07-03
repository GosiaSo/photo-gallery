using System;

namespace WebAPI.Models
{
    public class ImageDTO
    {

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }

    }
}
