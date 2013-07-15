using System;
using System.Collections.Generic;
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
        public long? CurrentRouteStepId { get; set; }
        public long? PreviousRouteStepId { get; set; }
        public IList<long> InQueueRouteSteps { get; set; }

        public RouteSagaData()
        {
            InQueueRouteSteps = new List<long>();
        }

        public void ChangeRouteStep(long routeStepId)
        {
            PreviousRouteStepId = CurrentRouteStepId;
            CurrentRouteStepId = routeStepId;
        }
    }
}