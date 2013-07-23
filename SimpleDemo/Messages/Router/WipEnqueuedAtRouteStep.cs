using System;
using NServiceBus;

namespace Messages.Router
{
    public class WipEnqueuedAtRouteStep : IEvent
    {
        public Guid WipId { get; set; }
        public int RouteStepId { get; set; } 
    }
}
