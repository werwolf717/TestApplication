using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Interfaces
{
    interface IEvent : IAnswer
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
