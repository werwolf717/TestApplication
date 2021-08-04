using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Classes.Services;
using TestApp.Models.Interfaces;

namespace TestApp.Classes
{
    public class SaveContent : ISaveContentService
    {
        public ISaveDbService _saveDb { get; }
        public ISaveStorageService _saveStorage { get; }
        public IConfiguration _config { get; }

        public SaveContent(IConfiguration config, ISaveDbService saveDb)
        {
            _config = config;
            _saveDb = saveDb;
        }


        public void SaveDbContent(IEnumerable<IEvent> answer, Guid _answerid)
        {
        }

        public void SaveDbContent(IAttachment _attachment, Guid _answerid)
        {
            throw new NotImplementedException();
        }

        public void SaveStorageContent(Guid answerId, IFormFile _file)
        {
            throw new NotImplementedException();
        }
    }
}
