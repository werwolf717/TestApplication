using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using TestApp.Models;
using Microsoft.AspNetCore.Http;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]/{answerId}/[action]")]
    public class AnswersController : ControllerBase
    {

        private readonly ILogger<AnswersController> _logger;
        public Dictionary<string, string> AnswerEvents;

        public AnswersController(ILogger<AnswersController> logger)
        {
            _logger = logger;
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

            TestApp.Classes.cSqlServer.WriteEvents(data);
            return Ok();
        }

    }
}
