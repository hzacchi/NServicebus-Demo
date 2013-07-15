using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Messages;

namespace Routing
{

    public class WipAggregate
    {
        private readonly WipState _state;

        public WipAggregate(WipState state)
        {
            _state = state;
        }

        //void Apply(IEvent<RegistrationId> e)
        //{
        //    _state.Mutate(e);
        //    Changes.Add(e);
        //}
    }

    public class WipState
    {
        public long Id { get; private set; }
        public long? LastRouteStepId { get; set; }
        public long? CurrentRouteStepId { get; private set; }
        public long? CurrentResourceId { get; private set; }

        public IList<long> InQueueRouteSteps { get; private set; }

        public void When(WipReleasedToRoute @event)
        {
            Id = @event.WipId;
        }

        public void When(WipEnqueuedAtRouteStep @event)
        {
            if (!InQueueRouteSteps.Contains(@event.RouteStepId))
            {
                InQueueRouteSteps.Add(@event.RouteStepId);
                CurrentRouteStepId = null;
                CurrentResourceId = null;
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
            InQueueRouteSteps = new List<long>();
        }

        public void Mutate(object e)
        {
            RedirectToWhen.InvokeEventOptional(this, e);
        }
    }
}