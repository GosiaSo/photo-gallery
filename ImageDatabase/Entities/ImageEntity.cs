using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDatabase.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Date = DateTime.Now.ToString("MM/dd/yyyy");
        public string Time = DateTime.Now.ToString("hh:mm tt");
        public string UserId { get; set; }
    }
}
