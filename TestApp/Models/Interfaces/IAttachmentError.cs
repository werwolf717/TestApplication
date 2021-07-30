using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Interfaces
{
    interface IAttachmentError
    {
        public string FileName { get; }
        public string Message { get; }
    }
}
