using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Backend.config
{
    public class ApplicationUploadFiles : IApplicationUploadFiles
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            var path = Path.Combine(
                       Directory.GetCurrentDirectory(), "wwwroot", "Uploads",
                       Guid.NewGuid().ToString("N") + "_" + file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return file.FileName;
        }
    }
}
