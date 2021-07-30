using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models.Interfaces;

namespace TestApp.Models
{
    public class AttachmentErrorModel : IAttachmentError
    {
        public string FileName { get; }
        public string Message { get; }
        public AttachmentErrorModel(string _FileName, string _Message)
        {
            FileName = _FileName;
            Message = _Message;
        }
    }
}
