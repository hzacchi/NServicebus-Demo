using System;
using NServiceBus;

namespace Contracts.Routing.Commands
{
    public class MoveWipToPackout : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Move wip to packout {0}", WipId);
        }
    }
}