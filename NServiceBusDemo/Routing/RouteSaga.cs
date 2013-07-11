using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Saga;

namespace Routing
{
    public class RouteSagaData : IContainSagaData
    {
        // the following properties are mandatory
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        // all other properties you want persisted
        public long WipId { get; set; }
        public long RouteId { get; set; }
        public long? RouteStepId { get; set; }
        public IList<long> InQueueRouteSteps { get; set; }

        public RouteSagaData()
        {
            InQueueRouteSteps = new List<long>();
        }
    }

    public class ReleaseWipToRoute : ICommand
    {
        public long WipId { get; set; }
        public long RouteId { get; set; }
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

    public class ArriveWipAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class WipArrivedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class WipOperationStartedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class WipOperationCompletedAtRouteStep : IEvent
    {
        public long WipId { get; set; }
        public long RouteStepId { get; set; }
    }

    public class RoutingHandlers :
        IHandleMessages<ReleaseWipToRoute>,
        IHandleMessages<WipReleasedToRoute>,
        IHandleMessages<EnqueueWipAtRouteStep>
    {
        public IBus Bus { get; set; }

        public void Handle(ReleaseWipToRoute message)
        {
            //find where to enqueue wip

            Bus.Publish(new WipReleasedToRoute {WipId = message.WipId, RouteId = 1});
        }

        public void Handle(WipReleasedToRoute message)
        {
            //determine where to enqueue

            Bus.Send(new EnqueueWipAtRouteStep { WipId = message.WipId, RouteStepId = 1 });
            Bus.Send(new EnqueueWipAtRouteStep { WipId = message.WipId, RouteStepId = 2 });
            Bus.Send(new EnqueueWipAtRouteStep { WipId = message.WipId, RouteStepId = 3 });
        }
         
        public void Handle(EnqueueWipAtRouteStep message)
        {
            throw new NotImplementedException();
        }
    }

    public class RoutingSaga : Saga<RouteSagaData>, 
                                  IAmStartedByMessages<WipReleasedToRoute>,
         
                                  IHandleMessages<WipEnqueuedAtRouteStep>,

                                  IHandleMessages<DequeueWipAtRouteStep>, 

                                  IHandleMessages<WipOperationStartedAtRouteStep>
    {  

        public void Handle(WipReleasedToRoute message)
        {
            Data.RouteId = message.RouteId;
        } 

        public void Handle(WipEnqueuedAtRouteStep message)
        {
            if (!Data.InQueueRouteSteps.Contains(message.RouteStepId))
            {
                Data.InQueueRouteSteps.Add(message.RouteStepId);
            } 
        } 

        public void Handle(DequeueWipAtRouteStep message)
        {
           if (Data.InQueueRouteSteps.Contains(message.RouteStepId))
           {
               Data.InQueueRouteSteps.Remove(message.RouteStepId);
               Bus.Publish(new WipDequeuedAtRouteStep { WipId = message.WipId, RouteStepId = message.RouteStepId });
           } 
        } 

        public void Handle(WipOperationStartedAtRouteStep message)
        {
            if (Data.InQueueRouteSteps.Contains(message.RouteStepId))
            {
                Data.InQueueRouteSteps.Add(message.RouteStepId);
            } 

            foreach (var routeStepId in Data.InQueueRouteSteps)
            {
                Bus.Send(new DequeueWipAtRouteStep {WipId = message.WipId, RouteStepId = routeStepId});
            }
        }
    }
}