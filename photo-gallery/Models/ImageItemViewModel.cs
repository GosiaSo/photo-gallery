using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
