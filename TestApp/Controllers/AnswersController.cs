using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public string Attachments(Guid answerId)
        {
            return "Test!";
        }

        [HttpPost]
        public string Events(Guid answerId, [FromForm] Dictionary<string, string> AnswerEvents)
        {

            
            return "Test!";

        }

    }
}
