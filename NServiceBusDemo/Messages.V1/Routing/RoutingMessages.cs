 
using Domain.Identities;
using NServiceBus;

namespace Messages.V1.Routing
{

    public class ReleaseWipToRoute : ICommand
    {
        public WipId WipId { get; set; }
        public long RouteId { get; set; }

        //Do these really belong here?
        public CustomerId CustomerId { get; set; }
        public MaterialId MaterialId { get; set; }
    }

    public class WipReleasedToRoute : IEvent
    {
        public WipId WipId { get; set; }
        public RouteId RouteId { get; set; }
    }

    public class EnqueueWipAtRouteStep : ICommand
    {
        public WipId WipId { get; set; }
        public RouteStepId RouteStepId { get; set; }
    }

    public class WipEnqueuedAtRouteStep : IEvent
    {
        public WipId WipId { get; set; }
        public RouteStepId RouteStepId { get; set; }
    }

    public class DequeueWipAtRouteStep : ICommand
    {
        public WipId WipId { get; set; }
        public RouteStepId RouteStepId { get; set; }
    }

    public class WipDequeuedAtRouteStep : IEvent
    {
        public WipId WipId { get; set; }
        public RouteStepId RouteStepId { get; set; }
    }

    public class ArriveWipAtResource : ICommand
    {
        public WipId WipId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    public class WipArrivedAtResource : IEvent
    {
        public WipId WipId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    
}
