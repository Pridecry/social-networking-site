using System;
using System.IO;
using DieteticSNS.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace DieteticSNS.WebUI.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly string uploadsFolder;

        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"img\uploads");
        }

        public string SaveImage(IFormFile file, int size = 500, bool compress = false)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (Image image = Image.Load(file.OpenReadStream()))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Crop,
                    Size = new Size(size, size)
                }));

                if (compress)
                {
                    var encoder = new JpegEncoder()
                    {
                        Quality = 100
                    }; 

                    image.Save(filePath, encoder);
                }
                else
                {
                    image.Save(filePath);
                }
            }

            return uniqueFileName;
        }

        public void DeleteImage(string fileName)
        {
            File.Delete(Path.Combine(uploadsFolder, fileName));
        }
    }
}
