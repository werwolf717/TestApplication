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
        public string Attachments(Guid answerId, IEnumerable<IFormFile> fileList)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "sample-container");
            blobContainerClient.CreateIfNotExists();
            return "Test!";
        }

        [HttpPost]
        public IActionResult Events(Guid answerId, EventModel data)
        {
            Classes.cSqlServer.connectionString = config.GetConnectionString("answersConnection");
            Classes.cSqlServer.WriteEvents(data, answerId);
            return Ok();
        }

    }
}
