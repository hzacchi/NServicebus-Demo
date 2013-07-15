using NServiceBus;

namespace Messages
{
    public class StartWipAtOperation : ICommand
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class WipOperationStartedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class WipOperationPassedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class WipOperationFailedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class WipOperationAbortedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }
}