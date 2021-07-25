using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("answers/{answerId}/[controller]")]
    public class AttachmentsController : ControllerBase
    {

        private readonly ILogger<AttachmentsController> _logger;

        public AttachmentsController(ILogger<AttachmentsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post(int answerId)
        {
            return "Test!";
        }

        [HttpGet]
        public string Eve(int answerId)
        {
            return "Test!";
        }

    }
}
