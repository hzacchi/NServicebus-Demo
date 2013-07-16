 
using Domain.Identities;
using NServiceBus;

namespace Messages.V1.Assemble
{
    public class AssemblePart : ICommand
    {
    }

    public class PartAssembled : IEvent
    {
        public MaterialId MaterialId { get; set; }
    }

    public class DisassemblePart : ICommand
    { 
    }

    public class PartDisassembled : IEvent
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    public class CompleteAssemble : ICommand
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }
}
