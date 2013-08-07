using System;
using NServiceBus;

namespace Contracts.Scrap.Events
{
    public class WipScrapped : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Wip scrapped {0}", WipId);
        }
    }
}