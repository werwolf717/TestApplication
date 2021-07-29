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
        public static string container;
        public static string connectionStr;
        public static void LoadFile(Guid answerId, IFormFile _file)
        {

            BlobContainerClient blobContainerClient = new BlobContainerClient(AttachmentWorker.connectionStr, AttachmentWorker.container);
            blobContainerClient.CreateIfNotExists();
            blobContainerClient.UploadBlob(_file.FileName, _file.OpenReadStream());
            SqlServer.WriteAttachment(new AttachmentModel(_file.FileName, MimeUtility.GetMimeMapping(_file.FileName) ?? MimeUtility.UnknownMimeType, _file.Length), answerId);

        }
    }
}
