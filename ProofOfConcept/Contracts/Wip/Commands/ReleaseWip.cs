using System;
using NServiceBus;

namespace Contracts.Wip.Commands
{
    public class ReleaseWip : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Release wip {0}", WipId);
        }
    }
}
