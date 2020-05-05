using site.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class PictureModel
    {
        public PictureModel(int id, byte[] ImageData, string FileName, string PictureName, string Description)
        {
            this.id = id;
            this.ImageData = ImageData;
            this.FileName = FileName;
            this.PictureName = PictureName;
            this.Description = Description;
        }

        public int id;
        public byte[] ImageData;

        public string fileName;
        public string FileName 
        {
            get
            {
                return (id.ToString() + fileName).Filtre(' ');
            }
            set
            {
                fileName = value;
            }
        }

        public string PictureName;
        public string Description;
    }
}
