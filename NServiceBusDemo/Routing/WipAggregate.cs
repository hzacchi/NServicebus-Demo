using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common;
using Messages;

namespace Routing
{
    public class WipApplicationState
    {
        
    }

    public class WipAggregate
    {
        private readonly WipState _state;

        public WipAggregate(WipState state)
        {
            _state = state;
        }

        public void Handle(EnqueueWipAtRouteStep command)
        {
            //Business logic
            Apply(new WipEnqueuedAtRouteStep {WipId = command.WipId, RouteStepId = command.RouteStepId});
        }


        void Apply(object e)
        {
            _state.Mutate(e);
            DomainEvents.Publish(e);
        }
    }

    public class WipState
    {
        public WipId WipId { get; private set; }
        public RouteStepId LastRouteStepId { get; set; }
        public RouteStepId CurrentRouteStepId { get; private set; }
        public ResourceId CurrentResourceId { get; private set; }

        public IList<RouteStepId> InQueueRouteSteps { get; private set; }

        public void When(WipReleasedToRoute @event)
        {
            WipId = @event.WipId;
        }

        public void When(WipEnqueuedAtRouteStep @event)
        {
            if (!InQueueRouteSteps.Contains(@event.RouteStepId))
            {
                InQueueRouteSteps.Add(@event.RouteStepId);
                CurrentRouteStepId = new RouteStepId();
                CurrentResourceId = new ResourceId();
            }
        }

        public void When(WipDequeuedAtRouteStep @event)
        {
            if (InQueueRouteSteps.Contains(@event.RouteStepId))
            {
                InQueueRouteSteps.Remove(@event.RouteStepId);
            }
        }

        public void When(OperationStartedAtRouteStep @event)
        {
            CurrentRouteStepId = @event.RouteStepId;
            CurrentResourceId = @event.ResourceId;
            InQueueRouteSteps.Clear();
        }

        public void When(OperationAbortedAtRouteStep @event)
        {
            LastRouteStepId = CurrentRouteStepId;
        }

        public void When(OperationFailedAtRouteStep @event)
        {
            LastRouteStepId = CurrentRouteStepId;
        }

        public void When(OperationPassedAtRouteStep @event)
        {
            LastRouteStepId = CurrentRouteStepId;
        }

        public WipState()
        {
            InQueueRouteSteps = new List<RouteStepId>();
        }

        public void Mutate(object e)
        {
            RedirectToWhen.InvokeEventOptional(this, e);
        }
    }
}