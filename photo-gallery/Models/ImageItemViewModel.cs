using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Models
{
    public class ImageItemViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }


        internal ImageDTO ToImageDto()
        {
            ImageDTO returnValue = new ImageDTO();

            returnValue.Id = Id;
            returnValue.Title = Title;
            returnValue.ImageUrl = ImageUrl;
            returnValue.Date = Date;
            returnValue.Comment = Comment;
            returnValue.UserId = UserId;

            return returnValue;
        }

        internal static ImageItemViewModel FromDto(ImageDTO dto)
        {
            ImageItemViewModel returnValue = new ImageItemViewModel();

            returnValue.Id = dto.Id;
            returnValue.Title = dto.Title;
            returnValue.ImageUrl = dto.ImageUrl;
            returnValue.Date = dto.Date;
            returnValue.Comment = dto.Comment;
            returnValue.UserId = dto.UserId;

            return returnValue;
        }
    }
}

