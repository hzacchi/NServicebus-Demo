using System;
using NServiceBus;

namespace Contracts.Packout.Commands
{
    public class PackWip : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Pack wip {0}", WipId);
        }
    }
}