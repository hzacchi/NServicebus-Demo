using System;

namespace Messages.Assemble
{
    public class OperationComplete
    {
        public Guid WipId { get; set; }
        public int RouteStepId { get; set; }
        public OperationResult Result { get; set; }
    }
}