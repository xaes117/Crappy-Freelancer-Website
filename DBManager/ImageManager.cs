using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace DBManager
{
    class ImageManager
    {
        private Cloudinary cloudinary;

        public ImageManager()
        {
            Account account = new Account(
                "cloud_name",
                "API_key",
                "API_secret");

            this.cloudinary = new Cloudinary(account);
        }

        public ImageUploadResult upload()
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"c:\my_image.jpg")
            };
            var uploadResult = this.cloudinary.Upload(uploadParams);

            return uploadResult;
        }
    }
}
