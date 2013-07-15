using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Messages
{

    public class ReleaseWipToRoute : ICommand
    {
        public long WipId { get; set; }
        public long RouteId { get; set; }

        //Do these really belong here?
        public long CustomerId { get; set; }
        public long MaterialId { get; set; }
    }

    public class WipReleasedToRoute : IEvent
    {
        public long WipId { get; set; }
        public long RouteId { get; set; }
    }

    public class EnqueueWipAtRouteStep : ICommand
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class WipEnqueuedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class DequeueWipAtRouteStep : ICommand
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class WipDequeuedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class ArriveWipAtResource : ICommand
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class WipArrivedAtResource : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    
}
