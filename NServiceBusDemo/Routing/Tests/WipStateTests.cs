using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using NUnit.Framework;

namespace Routing.Tests
{
    public class WipStateTests
    {
        [Test]
        public void when_wip_enqueued_then_state_inqueueroutesteps_updated()
        {
            var routeStepId = 7;
            var state = new WipState();

            //GIVEN

            //WHEN
            state.When(new WipEnqueuedAtRouteStep {WipId = 1, RouteStepId = routeStepId});

            //THEN
            Assert.AreEqual(routeStepId, state.InQueueRouteSteps.First());
        }

        [Test]
        public void when_operation_started_then_wip_is_dequeued_everywhere()
        { 
            var state = new WipState();

            //GIVEN
            state.When(new WipEnqueuedAtRouteStep { WipId = 1, RouteStepId = 1 });
            state.When(new WipEnqueuedAtRouteStep { WipId = 1, RouteStepId = 2 });
            state.When(new WipEnqueuedAtRouteStep { WipId = 1, RouteStepId = 3 });

            //WHEN
            state.When(new OperationStartedAtRouteStep {WipId = 1, ResourceId = 2, RouteStepId = 3});

            //THEN  
            Assert.AreEqual(0, state.InQueueRouteSteps.Count);
        }
    }
}
