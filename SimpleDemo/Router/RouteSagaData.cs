using System;
using System.Collections.Generic;
using NServiceBus.Saga;

namespace Router
{
    public class RouteSagaData : ContainSagaData
    {
        [Unique]
        public Guid WipId { get; set; }

        public IList<int> InQueue { get; set; }
        public int? InProcess { get; set; }
        public Stack<int> VisitedRouteSteps { get; set; } 

        public void ChangeRouteStep(int? step)
        {
            if (InProcess != null)
            {
                VisitedRouteSteps.Push(InProcess.Value);
            }
            InProcess = step;
        }

        public RouteSagaData()
        {
            InQueue = new List<int>();
            VisitedRouteSteps = new Stack<int>();
        }
    }
}