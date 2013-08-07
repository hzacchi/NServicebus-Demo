using System;
using NServiceBus;

namespace Contracts.Assemble.Commands
{
    public class PassAssemble : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Pass assemble for {0}", WipId);
        }
    }
}
