using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Classes.Services;
using TestApp.Models;

namespace TestApp.Classes
{
    public class SaveStorage : ISaveStorageService
    {
        private readonly IConfiguration _config;

        public SaveStorage(IConfiguration config)
        {
            _config = config;
        }
        public async Task LoadFile(IFormFile _file)
        {
            try
            {
                BlobContainerClient blobContainerClient = new BlobContainerClient(_config.GetConnectionString("blobConnection"), _config.GetSection("BlobContainers").GetValue<string>("answers"));
                blobContainerClient.CreateIfNotExists();
                await blobContainerClient.UploadBlobAsync(_file.FileName, _file.OpenReadStream());
            }
            catch (Exception ex)
            {
                throw new Exception(_file.FileName, ex);
            }
        }
    }
}
