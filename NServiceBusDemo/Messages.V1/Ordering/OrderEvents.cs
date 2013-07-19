using System;
using NServiceBus;

namespace Messages.V1.Ordering
{
    public class OrderCreated : IEvent
    {
        public Guid EventId { get; set; }
    }
}