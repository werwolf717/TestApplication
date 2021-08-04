using System;
using TestApp.Models.Interfaces;

namespace TestApp.Models.DB
{
    public class AnswerEvent : IAnswer, IEvent
    {

        public Guid Id { get; set; }
        public Guid AnswerId { get; set; }
        public DateTime Created { get; set; }
        public string Value { get; set; }
        public IEvent.AnswerEventTypeEnum Type { get; set; }
        public DateTime ClientTime { get; set; }

        public AnswerEvent(Guid guid1, Guid guid2, DateTime now, IEvent answer)
        {
            Id = guid1;
            AnswerId = guid2;
            Created = now;
            Value = answer.Value;
            Type = answer.Type;
            ClientTime = answer.ClientTime;
        }
    }
}
