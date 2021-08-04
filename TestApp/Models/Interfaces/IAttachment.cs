using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models.Interfaces
{
    public interface IAttachment
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public Int32 Size { get; set; }

    }
}
