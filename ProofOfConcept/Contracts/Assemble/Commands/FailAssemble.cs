using System;
using NServiceBus;

namespace Contracts.Assemble.Commands
{
    public class FailAssemble : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Fail assemble for {0}", WipId);
        }
    }
}