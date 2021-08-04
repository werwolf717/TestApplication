using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models.Interfaces
{
    public interface IEvent
    {
        enum AnswerEventTypeEnum
        {
            Click,
            Move,
            Drag,
            Press,
            Other
        }
        public string Value { get; set; }
        [Required]
        public AnswerEventTypeEnum Type { get; set; }
        [Required]
        public DateTime ClientTime { get; set; }
    }
}
