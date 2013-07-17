 
using Domain.Identities;
using NServiceBus;

namespace Messages.V1.Assemble
{
    public class AssemblePart : ICommand
    {
    }

    public class DisassemblePart : ICommand
    { 
    }

    public class CompleteAssemble : ICommand
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }
}
