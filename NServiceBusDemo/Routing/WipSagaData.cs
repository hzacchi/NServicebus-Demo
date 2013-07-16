using System;
using System.Collections.Generic;
using Common;
using NServiceBus.Saga;

namespace Routing
{
    public class WipSagaData : IContainSagaData
    {
        // the following properties are mandatory
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        // all other properties you want persisted
        public WipId WipId { get; set; }
        public RouteId RouteId { get; set; }
        public RouteStepId CurrentRouteStepId { get; set; }
        public RouteStepId PreviousRouteStepId { get; set; }
        public IList<RouteStepId> InQueueRouteSteps { get; set; }

        public void ChangeRouteStep(RouteStepId routeStepId)
        {
            PreviousRouteStepId = CurrentRouteStepId;
            CurrentRouteStepId = routeStepId;
        }

        public WipSagaData()
        {
            WipId = new WipId();
            RouteId = new RouteId();
            CurrentRouteStepId = new RouteStepId();
            PreviousRouteStepId = new RouteStepId();

            InQueueRouteSteps = new List<RouteStepId>();
        }
    }
}