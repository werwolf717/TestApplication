using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using TestApp.Models;
using TestApp.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using MimeMapping;
using TestApp.Models.Interfaces;

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
            SqlServer.connectionString = config.GetConnectionString("answersConnection");
            AttachmentWorker.container = config.GetSection("BlobContainers").GetValue<string>("answers");
            AttachmentWorker.connectionStr = config.GetConnectionString("blobConnection");
        }

        [HttpPost]
        public async Task<IActionResult> Attachments(Guid answerId, IEnumerable<IFormFile> File)
        {
            try
            {
                List<Task> taskList = new List<Task>();

                foreach (IFormFile _file in File)
                {

                    taskList.Add(Task.Run(() => AttachmentWorker.LoadFile(answerId, _file)));

                }

                await Task.WhenAll(taskList);
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, "Blob upload error!");
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Events(Guid answerId, IEnumerable<EventModel> data)
        {
            SqlServer.WriteEvents(data, answerId);
            return Ok();
        }

    }
}
