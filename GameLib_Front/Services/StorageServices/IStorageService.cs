﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Services.StorageServices
{
    public interface IStorageService
    {
        Task DeleteBlob(string photoUrl);

        Task<string> UploadPhoto(IFormFile file);
    }
}
