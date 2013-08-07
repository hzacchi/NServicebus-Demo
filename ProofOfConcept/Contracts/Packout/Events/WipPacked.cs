using System;
using NServiceBus;

namespace Contracts.Packout.Events
{
    public class WipPacked : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Wip packed out {0}", WipId);
        }
    }
}
