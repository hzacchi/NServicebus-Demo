using System;
using NServiceBus;

namespace Contracts.Routing.Commands
{
    public class MoveWipToScrap : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Move wip to scrap {0}", WipId);
        }
    }
}