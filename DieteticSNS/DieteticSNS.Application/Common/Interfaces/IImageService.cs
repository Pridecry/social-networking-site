using Microsoft.AspNetCore.Http;

namespace DieteticSNS.Application.Common.Interfaces
{
    public interface IImageService
    {
        string SaveImage(IFormFile file, int size = 500, bool compress = false);
        void DeleteImage(string fileName);
    }
}
