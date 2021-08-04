using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models.Interfaces;

namespace TestApp.Classes.Services
{
    public interface ISaveContentService
    {
        public Task SaveDbContent(IEnumerable<IEvent> answer, Guid _answerid);
        public Task SaveStorageContent(Guid answerId, IFormFile _file);
    }
}
