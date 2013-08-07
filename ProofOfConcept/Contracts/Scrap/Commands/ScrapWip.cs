using System;
using NServiceBus;

namespace Contracts.Scrap.Commands
{
    public class ScrapWip : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Scrap wip {0}", WipId);
        }
    }
}
