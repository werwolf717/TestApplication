using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Classes
{
    public class AttachmentWorker
    {
        public static async Task LoadFile(Guid answerId, IFormFile _file, IConfiguration config)
        {

            try
            {
                BlobContainerClient blobContainerClient = new BlobContainerClient(config.GetConnectionString("blobConnection"), config.GetSection("BlobContainers").GetValue<string>("answers"));
                blobContainerClient.CreateIfNotExists();
                await blobContainerClient.UploadBlobAsync(_file.FileName, _file.OpenReadStream());
                SqlServer.WriteAttachment(new AttachmentModel(_file.FileName, MimeUtility.GetMimeMapping(_file.FileName) ?? MimeUtility.UnknownMimeType, _file.Length), answerId, config);
            }
            catch(Exception ex)
            {
                throw new Exception(_file.FileName, ex);
            }

        }
    }
}
