using Microsoft.AspNetCore.Http;
using MimeMapping;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Classes.Services;
using TestApp.Models;
using TestApp.Models.Interfaces;

namespace TestApp.Classes
{
    public class SaveContent : ISaveContentService
    {
        private readonly AnswersContext _saveDb;

        private readonly ISaveStorageService _saveStorage;

        public SaveContent(AnswersContext saveDb, ISaveStorageService saveStorage)
        {
            _saveDb = saveDb;
            _saveStorage = saveStorage;
        }

        public async Task SaveDbContent(IEnumerable<IEvent> answer, Guid _answerid)
        {
            try
            {
                foreach (IEvent _event in answer)
                {
                    _saveDb.Event.Add(new(Guid.NewGuid(), _answerid, DateTime.Now, _event));
                }
                await _saveDb.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("SQL Error", ex.InnerException);
            }
        }

        public async Task SaveStorageContent(Guid answerId, IFormFile _file)
        {
            await _saveStorage.LoadFile(_file);
            _saveDb.Attachment.Add(new(Guid.NewGuid(), answerId, DateTime.Now, 
                                    new AttachmentModel(_file.FileName, MimeUtility.GetMimeMapping(_file.FileName) ?? MimeUtility.UnknownMimeType, 
                                    _file.Length)));
            try
            {
                await _saveDb.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("SQL Error", ex.InnerException);
            }
        }
    }
}
