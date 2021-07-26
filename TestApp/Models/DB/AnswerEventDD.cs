using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models.Interfaces;

namespace TestApp.Models.DB
{
    public class AnswerEventDD : IAnswer, IEvent
    {

        public AnswerEventDD(Guid guid1, Guid guid2, DateTime now, string value, IEvent.AnswerEventTypeEnum type, DateTime clientTime)
        {
            Id = guid1;
            AnswerId = guid2;
            Created = now;
            Value = value;
            Type = type;
            ClientTime = clientTime;
        }

        public Guid Id { get; set; }
        public Guid AnswerId { get; set; }
        public DateTime Created { get; set; }
        public string Value { get; set; }
        public IEvent.AnswerEventTypeEnum Type { get; set; }
        public DateTime ClientTime { get; set; }
    }
}
