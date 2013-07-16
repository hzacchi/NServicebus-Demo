using Common;
using NServiceBus;

namespace Messages
{
    public class StartWipAtOperation : ICommand
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    public class OperationStartedAtRouteStep : IEvent
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    public class OperationPassedAtRouteStep : IEvent
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    public class OperationFailedAtRouteStep : IEvent
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    public class OperationAbortedAtRouteStep : IEvent
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }
}