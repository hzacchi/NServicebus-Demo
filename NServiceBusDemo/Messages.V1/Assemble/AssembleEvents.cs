using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identities;
using NServiceBus;

namespace Messages.V1.Assemble
{ 
    public class PartDisassembled : IEvent
    {
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public RouteStepId RouteStepId { get; set; }
        public ResourceId ResourceId { get; set; }
    }

    public class PartAssembled : IEvent
    {
        public MaterialId MaterialId { get; set; }
    }
}
