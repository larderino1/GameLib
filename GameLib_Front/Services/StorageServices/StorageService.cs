using Azure.Storage.Blobs;
using GameLib_Front.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GameLib_Front.Services.StorageServices
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        private readonly string _containerName;

        public StorageService(
            BlobServiceClient blobServiceClient,
            IConfiguration config)
        {
            _blobServiceClient = blobServiceClient;

            _containerName = config.GetConnectionString(ConfigurationConstants.ContainerName);
        }

        public async Task DeleteBlob(string photoUrl)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            var blobName = ExtractBlobName(photoUrl);

            await containerClient.DeleteBlobIfExistsAsync(blobName);
        }

        public async Task<string> UploadPhoto(IFormFile file)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            var fileExtension = Path.GetExtension(file.FileName);

            var blobClient = containerClient.GetBlobClient($"{Guid.NewGuid()}.{fileExtension}");

            await blobClient.UploadAsync(file.OpenReadStream());

            return blobClient.Uri.AbsoluteUri;
        }

        private string ExtractBlobName(string photoUrl)
        {
            var array = photoUrl.Split("/");

            return array[^1];
        }
    }
}
