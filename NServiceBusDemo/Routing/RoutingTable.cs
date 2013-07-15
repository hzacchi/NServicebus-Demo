using System.Collections.Generic;

namespace Routing
{
    public class RoutingTable
    {
        private const long Assemble1 = 1;
        private const long Assemble2_A = 2;
        private const long Assemble2_B = 3;
        private const long Assemble3 = 4;
        private const long InspectionAndRework = 5;
        private const long Supermarket = 6;
        private const long Scrap = 7;

        public static long FirstStep()
        {
            return Assemble1;
        }

        public static long[] NextStespOnPass(long routeStepId, long previousStep)
        {
            switch (routeStepId)
            {
                case 1:
                    return new long[] {Assemble2_A, Assemble2_B};
                case 2:
                    return new long[] {Assemble3};
                case 3:
                    return new long[] {Assemble3};
                case 4:
                    return new long[] {Supermarket};
                case 5:
                    return new long[] {previousStep};
                default:
                    return new long[] {}; //terminating step
            }
        }

        public static long[] NextStepsOnFail(long routeStepId)
        {
            switch (routeStepId)
            {
                case InspectionAndRework:
                    return new long[] {Scrap};
                default:
                    return new long[] {InspectionAndRework};
            }
        }

        public static long[] NextStepsOnAbort(long routeStepId)
        {
            //reenqueue at same step
            return new long[] {routeStepId};
        }
    }
}