using System;
using Xunit;
using TestApp;
using TestApp.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using TestApp.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using TestApp.Models;

namespace UnitAppTests
{
    public class AnswersControllerUnit
    {
        [Fact]
        public void EventsReturnNotNull()
        {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var aswContext = new AnswersContext(config);
            var saveStorage = new SaveStorage(config);


            AnswersController controller = new AnswersController(new Logger<AnswersController>(LoggerFactory.Create(builder =>
            builder.AddConsole())),

            new SaveContent(aswContext, saveStorage));


            Task result = controller.Events(Guid.NewGuid(), new List<EventModel>());

            result.Wait();

            Assert.IsType<Task<IActionResult>>(result);

        }
    }
}
