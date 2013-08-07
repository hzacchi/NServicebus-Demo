using System;
using NServiceBus;

namespace Contracts.Wip.Events
{
    public class WipReleased : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Wip released {0}", WipId);
        }
    }
}