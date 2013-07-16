using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NServiceBus;

namespace Messages
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
