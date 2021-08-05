using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Models.Interfaces;

namespace TestApp.Classes.Interfaces
{
    public interface ISaveContentService
    {
        public Task SaveDbContent(IEnumerable<IEvent> answer, Guid _answerid);
        public Task SaveStorageContent(Guid answerId, IFormFile _file);
    }
}
