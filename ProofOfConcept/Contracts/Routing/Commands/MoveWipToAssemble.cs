using System;
using NServiceBus;

namespace Contracts.Routing.Commands
{
    public class MoveWipToAssemble : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Move wip to assemble {0}", WipId);
        }
    }
}
