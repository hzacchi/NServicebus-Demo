using System;
using NServiceBus;

namespace Messages.Router
{
    public class WipDequeuedAtRouteStep : IEvent
    {
        public Guid WipId { get; set; }
        public int RouteStepId { get; set; }

        public WipDequeuedAtRouteStep()
        {
            WipId = Guid.NewGuid();
        }
    }
}