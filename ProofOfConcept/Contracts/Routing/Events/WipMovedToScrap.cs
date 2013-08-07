using System;
using NServiceBus;

namespace Contracts.Routing.Events
{
    public class WipMovedToScrap : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Wip moved to scrap for {0}", WipId);
        }
    }
}