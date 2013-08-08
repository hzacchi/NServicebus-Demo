using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Contracts.Assemble.Commands
{
    public class StartAssemble : ICommand
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Start assemble for {0}", WipId);
        }
    }
}
