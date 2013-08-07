using System;
using NServiceBus;

namespace Contracts.Routing.Events
{
    public class WipMovedToAssemble : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Wip moved to assemble for {0}", WipId);
        }
    }
}