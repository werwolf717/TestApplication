using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TestApp.Models.Interfaces;
using TestApp.Classes.Interfaces;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]/{answerId}/[action]")]
    public class AnswersController : ControllerBase
    {

        private readonly ILogger<AnswersController> logger;
        private readonly ISaveContentService saveContent;

        public AnswersController(ILogger<AnswersController> _logger, IConfiguration _config, ISaveContentService _saveContent)
        {
            logger = _logger;
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
            Dictionary<string, IAttachmentError> answer = new Dictionary<string, IAttachmentError>();
            answer.Add("Errors", null);
            try
            {
                await saveContent.SaveDbContent(data, answerId);
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
                logger.Log(LogLevel.Error, "Error with: " + ex.Message + "\n" + ex.InnerException.Message);

                answer["Errors"] = new AttachmentErrorModel(ex.Message, ex.InnerException.Message);
            }
            return Ok(answer);
        }

    }
}
