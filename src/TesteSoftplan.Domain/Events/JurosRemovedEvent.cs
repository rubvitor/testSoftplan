using System;
using NetDevPack.Messaging;

namespace TesteSoftplan.Domain.Events
{
    public class JurosRemovedEvent : Event
    {
        public JurosRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}