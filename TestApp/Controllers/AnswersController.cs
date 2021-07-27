using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using TestApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]/{answerId}/[action]")]
    public class AnswersController : ControllerBase
    {

        private readonly ILogger<AnswersController> logger;
        private readonly IConfiguration config;

        public AnswersController(ILogger<AnswersController> _logger, IConfiguration _config)
        {
            logger = _logger;
            config = _config;
        }

        [HttpPost]
        public async Task<IActionResult> Attachments(Guid answerId, IEnumerable<IFormFile> File)
        {
            try
            {
                BlobContainerClient blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "answers-container");
                blobContainerClient.CreateIfNotExists();

                foreach(IFormFile _file in File)
                {
                    await blobContainerClient.UploadBlobAsync(_file.FileName, _file.OpenReadStream());
                }
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, "Blob upload error!");
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Events(Guid answerId, EventModel data)
        {
            Classes.SqlServer.connectionString = config.GetConnectionString("answersConnection");
            Classes.SqlServer.WriteEvents(data, answerId);
            return Ok();
        }

    }
}
