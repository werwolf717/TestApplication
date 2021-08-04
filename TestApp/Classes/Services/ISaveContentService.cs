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
        public ISaveDbService _saveDb { get; }
        public ISaveStorageService _saveStorage { get; }
        public IConfiguration _config { get; }

        public void SaveDbContent(IEnumerable<IEvent> answer, Guid _answerid);
        public void SaveDbContent(IAttachment _attachment, Guid _answerid);
        public void SaveStorageContent(Guid answerId, IFormFile _file);
    }
}
