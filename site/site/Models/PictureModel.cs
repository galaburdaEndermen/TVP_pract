using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class PictureModel
    {
        public PictureModel(int id, byte[] ImageData, string FileName, string Description)
        {
            this.id = id;
            this.ImageData = ImageData;
            this.FileName = FileName;
            this.Description = Description;
        }

        public int id;
        public byte[] ImageData;
        public string FileName;
        public string Description;
    }
}
}