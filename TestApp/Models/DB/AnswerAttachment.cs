using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models.Interfaces;

namespace TestApp.Models.DB
{
    public class AnswerAttachment : IAnswer, IAttachment
    {
        public Guid Id { get; set; }
        public Guid AnswerId { get; set; }
        public DateTime Created { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }

        public AnswerAttachment(Guid guid1, Guid guid2, DateTime now, IAttachment attachment)
        {
            Id = guid1;
            AnswerId = guid2;
            Created = now;
            FileName = attachment.FileName;
            MimeType = attachment.MimeType;
            Size = attachment.Size;
        }
    }
}
