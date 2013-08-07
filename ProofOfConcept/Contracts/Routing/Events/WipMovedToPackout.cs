using System;
using NServiceBus;

namespace Contracts.Routing.Events
{
    public class WipMovedToPackout : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Wip moved to packout for {0}", WipId);
        }
    }
}