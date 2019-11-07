using System;
using System.IO;
using System.Text.RegularExpressions;
using DieteticSNS.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using SixLabors.Memory;
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

            Configuration.Default.MemoryAllocator = ArrayPoolMemoryAllocator.CreateDefault();
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
                    Position = AnchorPositionMode.Center,
                    Size = new Size(size, size),
                }));

                if (compress)
                {
                    var encoder = new JpegEncoder()
                    {
                        //default value - 75
                        Quality = 60
                    }; 

                    image.Save(filePath, encoder);
                }
                else
                {
                    image.Save(filePath);
                }
            }

            Configuration.Default.MemoryAllocator.ReleaseRetainedResources();

            return uniqueFileName;
        }

        public void DeleteImage(string fileName)
        {
            File.Delete(Path.Combine(uploadsFolder, fileName));
        }
    }
}
