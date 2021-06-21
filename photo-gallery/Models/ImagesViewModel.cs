using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ImagesViewModel
    {
        public ImageItemViewModel[] Images { get; set; }

        public ImagesViewModel()
        {
            Images = new ImageItemViewModel[0];
        }
    }

    


}
