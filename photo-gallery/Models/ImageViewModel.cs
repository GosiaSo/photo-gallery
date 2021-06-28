using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
