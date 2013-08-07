using System;
using NServiceBus;

namespace Contracts.Assemble.Events
{
    public class AssembleFailed : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Assemble failed for {0}", WipId);
        }
    }
}