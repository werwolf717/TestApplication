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
using TestApp.Classes.Services;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]/{answerId}/[action]")]
    public class AnswersController : ControllerBase
    {

        private readonly ILogger<AnswersController> logger;
        private readonly IConfiguration config;
        private readonly ISaveContentService saveContent;

        public AnswersController(ILogger<AnswersController> _logger, IConfiguration _config, ISaveContentService _saveContent)
        {
            logger = _logger;
            config = _config;
            saveContent = _saveContent;
        }

        [HttpPost]
        public async Task<IActionResult> Attachments(Guid answerId, IEnumerable<IFormFile> File)
        {
            Task controlAll = null;
            List<IAttachmentError> errorList = new List<IAttachmentError>();
            Dictionary<string, List<IAttachmentError>> answer = new Dictionary<string, List<IAttachmentError>>();
            answer.Add("Errors", null);
            try
            {
                List<Task> taskList = new List<Task>();

                foreach (IFormFile _file in File)
                {
                    taskList.Add(Task.Run(() => 
                        saveContent.SaveStorageContent(answerId, _file)));
                }

                controlAll = Task.WhenAll(taskList);
                await controlAll;
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
                logger.Log(LogLevel.Error, "Tasks fauled: " + controlAll.IsFaulted);

                foreach(var inEx in controlAll.Exception.InnerExceptions)
                {
                    logger.Log(LogLevel.Error, "Error with: " + inEx.Message + "\n" + inEx.InnerException.Message);
                    errorList.Add(new AttachmentErrorModel(inEx.Message, inEx.InnerException.Message));
                }
                answer["Errors"] = errorList;
            }

            return Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> Events(Guid answerId, IEnumerable<EventModel> data)
        {
            try
            {
                // await SqlServer.WriteEventsAsync(data, answerId, config);
                await saveContent.SaveDbContent(data, answerId);
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }

    }
}
