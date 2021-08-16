using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models.Interfaces
{
    public interface IEvent
    {
        enum AnswerEventType
        {
            Click,
            Move,
            Drag,
            Press,
            Other
        }
        public string Value { get; set; }
        [Required]
        public AnswerEventType Type { get; set; }
        [Required]
        public DateTime ClientTime { get; set; }
    }
}
