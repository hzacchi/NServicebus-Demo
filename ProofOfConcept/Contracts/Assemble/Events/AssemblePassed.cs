using System;
using NServiceBus;

namespace Contracts.Assemble.Events
{
    public class AssemblePassed : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Assemble passed for {0}", WipId);
        }
    }
}