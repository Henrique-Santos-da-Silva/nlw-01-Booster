using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.config
{
    public interface IApplicationUploadFiles
    {
        Task<string> UploadFile(IFormFile file);
    }
}
