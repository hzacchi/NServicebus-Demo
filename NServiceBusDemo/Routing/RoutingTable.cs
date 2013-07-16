using System.Collections.Generic;
using Common;
using Domain.Identities;

namespace Routing
{
    public class RoutingTable
    {
        private static RouteStepId Assemble1 = new RouteStepId(1);
        private static RouteStepId Assemble2_A = new RouteStepId(2);
        private static RouteStepId Assemble2_B = new RouteStepId(3);
        private static RouteStepId Assemble3 = new RouteStepId(4);
        private static RouteStepId InspectionAndRework = new RouteStepId(5);
        private static RouteStepId Supermarket = new RouteStepId(6);
        private static RouteStepId Scrap = new RouteStepId(7);

        public static RouteStepId FirstStep()
        {
            return Assemble1;
        }

        public static RouteStepId[] NextStespOnPass(RouteStepId routeStepId, RouteStepId previousStep)
        {
            switch (routeStepId.Id)
            {
                case 1:
                    return new RouteStepId[] { Assemble2_A, Assemble2_B };
                case 2:
                    return new RouteStepId[] { Assemble3 };
                case 3:
                    return new RouteStepId[] { Assemble3 };
                case 4:
                    return new RouteStepId[] { Supermarket };
                case 5:
                    return new RouteStepId[] { previousStep };
                default:
                    return new RouteStepId[] { }; //terminating step
            }
        }

        public static RouteStepId[] NextStepsOnFail(RouteStepId routeStepId)
        {
            return routeStepId == InspectionAndRework
                       ? new RouteStepId[] {Scrap}
                       : new RouteStepId[] {InspectionAndRework};
        }

        public static RouteStepId[] NextStepsOnAbort(RouteStepId routeStepId)
        {
            //reenqueue at same step
            return new RouteStepId[] { routeStepId };
        }
    }
}