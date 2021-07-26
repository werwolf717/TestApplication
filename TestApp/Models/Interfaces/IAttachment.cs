using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Interfaces
{
    public interface IAttachment : IAnswer
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public Int32 Size { get; set; }

    }
}
