using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

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
        public string Attachments(Guid answerId)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "sample-container");
            blobContainerClient.CreateIfNotExists();
            return "Test!";
        }

        [HttpPost]
        public string Events(Guid answerId, Dictionary<string, string> data)
        {

            return "Test";

        }

    }
}
