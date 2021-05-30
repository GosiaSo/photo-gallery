using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ImageDTO
    {

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Date = DateTime.Now.ToString("MM/dd/yyyy");
        public string Time = DateTime.Now.ToString("hh:mm tt");
        public string OwnerId { get; set; }

    }
}
