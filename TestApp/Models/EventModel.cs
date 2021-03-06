using System;
using TestApp.Models.Interfaces;

namespace TestApp.Models
{
    public class EventModel : IEvent
    {
        public string Value { get; set; }
        public IEvent.AnswerEventTypeEnum Type { get; set; }
        public DateTime ClientTime { get; set; }
    }
}
