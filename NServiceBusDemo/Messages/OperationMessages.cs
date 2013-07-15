using NServiceBus;

namespace Messages
{
    public class StartWipAtOperation : ICommand
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class OperationStartedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class OperationPassedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class OperationFailedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }

    public class OperationAbortedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
        public long ResourceId { get; set; }
    }
}